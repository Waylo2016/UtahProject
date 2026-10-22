using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtahProject.Api.Models;

namespace UtahProject.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :IdentityDbContext<UserModel>(options)
{
    
    public DbSet<UserModel> Users { get; set; }
    public DbSet<LoreModel> Lore { get; set; }
    public DbSet<SpeciesModel> Species { get; set; }
    public DbSet<DinosaurModel> Dinosaurs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
    }
}