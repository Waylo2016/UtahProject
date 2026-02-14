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
    public DbSet<Dino_Mutation> DinoTraits { get; set; }
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
            .HasKey(d => d.dinoCode);
        
        
        // Dinosaur - Mutation (Many-to-Many via Dino_Mutation)
        builder.Entity<Dino_Mutation>()
            .HasKey(dm => new { dm.dinoCode, dm.mutationCode });
        
        builder.Entity<Mutation_Lib>()
            .HasKey(ml => ml.mutationCode);

        builder.Entity<Dino_Mutation>()
            .HasOne(dm => dm.dinosaur)
            .WithMany(d => d.dinoMutations)
            .HasForeignKey(dm => dm.dinoCode);

        // Dinosaur - Relationship (One-to-Many via Dino_Relationship)
        builder.Entity<Dino_Relationship>()
            .HasKey(dr => new { dr.dinocode, dr.targetDinocode, dr.relationTypeId });

        builder.Entity<Dino_Relationship>()
            .HasOne(dr => dr.Dino)
            .WithMany(d => d.dinoRelationships)
            .HasForeignKey(dr => dr.dinocode)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Dino_Relationship>()
            .HasOne(dr => dr.TargetDino)
            .WithMany() // One-to-Many: Target doesn't have a back-collection
            .HasForeignKey(dr => dr.targetDinocode)
            .OnDelete(DeleteBehavior.Restrict);

        // Nesting - Parents and Offspring
        builder.Entity<Nesting_Lib>()
            .HasKey(n => n.nestingId);
        
        builder.Entity<Nesting_Lib>()
            .HasOne(n => n.parent1)
            .WithMany(d => d.nestingsAsParent1)
            .HasForeignKey(n => n.parent1Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Nesting_Lib>()
            .HasOne(n => n.parent2)
            .WithMany(d => d.nestingsAsParent2)
            .HasForeignKey(n => n.parent2Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Dinosaur>()
            .HasOne(d => d.nest)
            .WithMany(n => n.offsprings)
            .HasForeignKey(d => d.nestId)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Dino - Behaviour
        builder.Entity<Dino_Behaviour>()
            .HasKey(db => new { db.dinoCode, db.behaviourCode });
        
        builder.Entity<Behaviour_Lib>()
            .HasKey(bl => bl.behaviourCode);

        builder.Entity<Dino_Behaviour>()
            .HasOne(db => db.dinosaur)
            .WithMany(d => d.dinoBehaviours)
            .HasForeignKey(db => db.dinoCode);

        builder.Entity<Dino_Behaviour>()
            .HasOne(db => db.Behaviour)
            .WithMany() 
            .HasForeignKey(db => db.behaviourCode);

        // Dino - Nesting
        builder.Entity<Dino_Nesting>()
            .HasKey(dn => new { dn.dinoCode, dn.nestingId });

        builder.Entity<Dino_Nesting>()
            .HasOne(dn => dn.Dinosaur)
            .WithMany()
            .HasForeignKey(dn => dn.dinoCode);

        builder.Entity<Dino_Nesting>()
            .HasOne(dn => dn.nesting)
            .WithMany()
            .HasForeignKey(dn => dn.nestingId);

        // Nesting - Mutation
        builder.Entity<Nesting_Mutation>()
            .HasKey(nm => new { nm.nestingId, nm.mutationCode });

        builder.Entity<Nesting_Mutation>()
            .HasOne(nm => nm.nesting)
            .WithMany()
            .HasForeignKey(nm => nm.nestingId);

        builder.Entity<Nesting_Mutation>()
            .HasOne(nm => nm.Mutation)
            .WithMany()
            .HasForeignKey(nm => nm.mutationCode);

        // Species
        builder.Entity<Species>()
            .HasKey(s => s.speciesId);

        // Relation_Type
        builder.Entity<Relation_Type>()
            .HasKey(rt => rt.relationTypeId);
    }
    
}