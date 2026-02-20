using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Utah_Project_API.Models;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    
    public DbSet<Dinosaur> Dinosaurs { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Mutation_Lib> Mutations { get; set; }
    public DbSet<Dino_Mutation> DinoMutations { get; set; }
    public DbSet<Behaviour_Lib> Behaviours { get; set; }
    public DbSet<Dino_Behaviour> DinoBehaviours { get; set; }
    public DbSet<Nesting_Lib> Nestings { get; set; }
    public DbSet<Dino_Nesting> DinoNestings { get; set; }
    public DbSet<Nesting_Mutation> NestingMutations { get; set; }
    public DbSet<Relation_Type> RelationTypes { get; set; }
    public DbSet<Dino_Relationship> DinoRelationships { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Dinosaur>()
            .HasKey(d => d.DinoCode);
        
        
        // Dinosaur - Mutation (Many-to-Many via Dino_Mutation)
        builder.Entity<Dino_Mutation>()
            .HasKey(dm => new { dm.DinoCode, dm.MutationCode });
        
        builder.Entity<Mutation_Lib>()
            .HasKey(ml => ml.MutationCode);

        builder.Entity<Dino_Mutation>()
            .HasOne(dm => dm.Dinosaur)
            .WithMany(d => d.DinoMutations)
            .HasForeignKey(dm => dm.DinoCode);

        // Dinosaur - Relationship (One-to-Many via Dino_Relationship)
        builder.Entity<Dino_Relationship>()
            .HasKey(dr => new { dr.DinoCode, dr.TargetDinoCode, dr.RelationTypeId });

        builder.Entity<Dino_Relationship>()
            .HasOne(dr => dr.Dino)
            .WithMany(d => d.DinoRelationships)
            .HasForeignKey(dr => dr.DinoCode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Dino_Relationship>()
            .HasOne(dr => dr.TargetDino)
            .WithMany() // One-to-Many: Target doesn't have a back-collection
            .HasForeignKey(dr => dr.TargetDinoCode)
            .OnDelete(DeleteBehavior.Restrict);

        // Nesting - Parents and Offspring
        builder.Entity<Nesting_Lib>()
            .HasKey(n => n.NestingId);
        
        builder.Entity<Nesting_Lib>()
            .HasOne(n => n.Parent1)
            .WithMany(d => d.NestingsAsParent1)
            .HasForeignKey(n => n.Parent1Code)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Nesting_Lib>()
            .HasOne(n => n.Parent2)
            .WithMany(d => d.NestingsAsParent2)
            .HasForeignKey(n => n.Parent2Code)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Dinosaur>()
            .HasOne(d => d.Nest)
            .WithMany(n => n.Offsprings)
            .HasForeignKey(d => d.NestId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Dino - Behaviour
        builder.Entity<Dino_Behaviour>()
            .HasKey(db => new { db.DinoCode, db.BehaviourCode });
        
        builder.Entity<Behaviour_Lib>()
            .HasKey(bl => bl.BehaviourCode);

        builder.Entity<Dino_Behaviour>()
            .HasOne(db => db.Dinosaur)
            .WithMany(d => d.DinoBehaviours)
            .HasForeignKey(db => db.DinoCode);

        builder.Entity<Dino_Behaviour>()
            .HasOne(db => db.Behaviour)
            .WithMany() 
            .HasForeignKey(db => db.BehaviourCode);

        // Dino - Nesting
        builder.Entity<Dino_Nesting>()
            .HasKey(dn => new { dn.DinoCode, dn.NestingId });

        builder.Entity<Dino_Nesting>()
            .HasOne(dn => dn.Dinosaur)
            .WithMany()
            .HasForeignKey(dn => dn.DinoCode);

        builder.Entity<Dino_Nesting>()
            .HasOne(dn => dn.Nesting)
            .WithMany()
            .HasForeignKey(dn => dn.NestingId);

        // Nesting - Mutation
        builder.Entity<Nesting_Mutation>()
            .HasKey(nm => new { nestingId = nm.NestingId, nm.MutationCode });

        builder.Entity<Nesting_Mutation>()
            .HasOne(nm => nm.Nesting)
            .WithMany()
            .HasForeignKey(nm => nm.NestingId);

        builder.Entity<Nesting_Mutation>()
            .HasOne(nm => nm.Mutation)
            .WithMany()
            .HasForeignKey(nm => nm.MutationCode);

        // Species
        builder.Entity<Species>()
            .HasKey(s => s.SpeciesId);

        // Relation_Type
        builder.Entity<Relation_Type>()
            .HasKey(rt => rt.Id);
    }
    
}