using Projects;

namespace Utah_Project.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var sql = builder.AddSqlServer("sql");
        
        var db = sql.AddDatabase("UtahDB");

        var api = builder.AddProject<Utah_Project_API>("api")
            .WithReference(db)
            .WaitFor(db);
        
        var website = builder.AddProject<Utah_Project_Web>("website")
            .WithReference(api)
            .WaitFor(api);
        
        builder.Build().Run();
    }
}
