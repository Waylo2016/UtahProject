using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtahProject.Api.Models;

namespace UtahProject.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :IdentityDbContext<UserModel>(options)
{
    // Configure the database context
    public DbSet<UserModel> Users { get; set; }
    public DbSet<LoreModel> Lore { get; set; }
    public DbSet<SpeciesModel> Species { get; set; }
    public DbSet<DinosaurModel> Dinosaurs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dinosaur model configuring
        modelBuilder.Entity<DinosaurModel>()
            .HasKey(d => d.DinoId);

        modelBuilder.Entity<DinosaurModel>()
            .Property(d => d.DinoId)
            .ValueGeneratedOnAdd();


        // User model configuring
        modelBuilder.Entity<UserModel>()
            .Property(u => u.DinoOwner)
            .ValueGeneratedNever();
        
        // Species model configuring
        modelBuilder.Entity<SpeciesModel>()
            .HasKey(s => s.SpeciesId);
        
        modelBuilder.Entity<SpeciesModel>()
            .Property(s => s.SpeciesId)
            .ValueGeneratedOnAdd();

        // Lore model configuration
        modelBuilder.Entity<LoreModel>()
            .HasKey(l => l.LoreId);
        
        modelBuilder.Entity<LoreModel>()
            .Property(l => l.LoreId)
            .ValueGeneratedOnAdd();
    }
}