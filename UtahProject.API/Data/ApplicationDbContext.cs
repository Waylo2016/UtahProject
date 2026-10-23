using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtahProject.Api.Models;

namespace UtahProject.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserModel, IdentityRole<Guid>, Guid>(options)
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

        modelBuilder.Entity<DinosaurModel>()
            .Property(d => d.SpeciesId)
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

        // Relationships

        // Species 1 - * Dinosaur
        modelBuilder.Entity<SpeciesModel>()
            .HasMany(s => s.Dinosaurs)
            .WithOne(d => d.Species)
            .HasForeignKey(d => d.SpeciesId)
            .IsRequired();

        // Dinosaur 1 - * Lore
        modelBuilder.Entity<DinosaurModel>()
            .HasMany(d => d.Lore)
            .WithOne(l => l.Dinosaur)
            .HasForeignKey(l => l.DinoId)
            .IsRequired();

        // User 1 - * Dinosaur
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Dinosaurs)
            .WithOne(d => d.Owner)
            .HasForeignKey(d => d.OwnedBy)
            .IsRequired();

    }
}