using Aspire.Hosting;

namespace UtahProject.AppHost;

public class AppHost
{
    public static void Main(string[] args)
    {
            var builder = DistributedApplication.CreateBuilder(args);

            var postgres = builder.AddPostgres("postgres");
            
            var utahDb = postgres.AddDatabase("UtahDb");

            var api = builder.AddProject<Projects.UtahProject_Api>("utahproject-api")
                .WithExternalHttpEndpoints()
                .WithReference(utahDb);

            builder.Build()
                .Run();
    }
}