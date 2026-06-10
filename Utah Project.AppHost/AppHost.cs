
using Projects;

namespace Utah_Project.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        var sql = builder.AddPostgres("SQL")
            .WithLifetime(ContainerLifetime.Persistent)
            .WithContainerName("UtahSQL")
            .WithHostPort(62617)
            .WithDataBindMount("..Data/sql_data")
            .WithPgAdmin();
            
        var db = sql.AddDatabase("UtahDB");
        

        var api = builder.AddProject<Utah_Project_API>("api")
            .WithReference(db)
            .WaitFor(db);
        
        builder.Build().Run();
    }
}
