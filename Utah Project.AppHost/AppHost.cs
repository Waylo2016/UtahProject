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
        

        IResourceBuilder<ProjectResource> api = builder.AddProject<Utah_Project_API>("api")
            .WaitFor(db)
            .WithReference(db);

        builder.AddContainer("data-api", "mcr.microsoft.com/azure-databases/data-api-builder")
            .WithBindMount("dab-config.json", "/App/dab-config.json", isReadOnly: true)
            .WithArgs("start", "--ConfigFileName", "/App/dab-config.json")
            .WithHttpEndpoint(targetPort: 5000, port:5000, name: "http")
            .WithEnvironment("DATABASE_CONNECTION_STRING", db)
            .WithExternalHttpEndpoints()
            .WaitFor(db)
            .WaitFor(api);

        builder.Build().Run();
    }
}
