using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Utah_Project_API.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=62617;Database=UtahDB;Username=postgres;Password=D_6xD89wJ5jyXF~)AHtw{n;"
        );

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

