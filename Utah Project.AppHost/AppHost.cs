using Projects;

namespace Utah_Project.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var sql = builder.AddSqlServer("sql");
        
        var db = sql.AddDatabase("sqldb");

        builder.AddProject<Utah_Project_API>("api")
            .WithReference(db);
        
        builder.Build().Run();
    }
}
