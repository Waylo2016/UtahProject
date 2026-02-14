using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Utah_Project_API.Models;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    
    public DbSet<Dinosaur> Dinosaurs { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Mutation_Lib> Traits { get; set; }
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

        // Dinosaur - Mutation (Many-to-Many via Dino_Mutation)
        builder.Entity<Dino_Mutation>()
            .HasKey(dm => new { dm.dinoCode, dm.mutationCode });

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
    }
}