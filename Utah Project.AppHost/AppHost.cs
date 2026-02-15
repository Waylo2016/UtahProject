using Aspire.Hosting;
using Aspire.Hosting.JavaScript;
using Projects;

namespace Utah_Project.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<SqlServerServerResource> sql = builder.AddSqlServer("sql", port: 62617)
            .WithDataBindMount("..Data/sql_data");
            
        IResourceBuilder<SqlServerDatabaseResource> db = sql.AddDatabase("UtahDB");



        IResourceBuilder<ProjectResource> api = builder.AddProject<Utah_Project_API>("api")
            .WaitFor(db)
            .WithReference(db);
        
        
        builder.Build().Run();
    }
}
