using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Utah_Project_API.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        optionsBuilder.UseSqlServer("Server=127.0.0.1,62617;Database=UtahDB;User ID=sa;Password=D_6xD89wJ5jyXF~)AHtw{n;TrustServerCertificate=true");
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

