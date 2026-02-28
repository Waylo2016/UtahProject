using Aspire.Hosting;
using Aspire.Hosting.JavaScript;
using Projects;

namespace Utah_Project.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<SqlServerServerResource> sql = builder.AddSqlServer("SQL")
            .WithLifetime(ContainerLifetime.Persistent)
            .WithContainerName("UtahSQL")
            .WithHostPort(62617)
            .WithDataBindMount("..Data/sql_data");
            
        IResourceBuilder<SqlServerDatabaseResource> db = sql.AddDatabase("UtahDB");
        

        var api = builder.AddProject<Utah_Project_API>("api")
            .WithReference(db)
            .WaitFor(db);
        
        var website = builder.AddProject<Utah_Project_Web>("website")
            .WithReference(api)
            .WaitFor(api);
        
        builder.Build().Run();
    }
}
