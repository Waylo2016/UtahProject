using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace UtahProject.AppHost;

public class AppHost
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var pgUser = builder.AddParameter("pg-user", secret: true);
        
        var postgres = builder.AddPostgres("postgres", userName: pgUser, port: 5432)
            .WithDataVolume()
            .WithLifetime(ContainerLifetime.Persistent)
            .WithPgAdmin();

        var utahDb = postgres.AddDatabase("UtahDb");

        var api = builder.AddProject<Projects.UtahProject_Api>("utahproject-api")
            .WithExternalHttpEndpoints()
            .WithReference(utahDb);

        var apiMigrations = api.AddEFMigrations("api-migrations")
            .RunDatabaseUpdateOnStart();
        
        api.WaitForCompletion(apiMigrations);

        builder.Build()
            .Run();
    }
}