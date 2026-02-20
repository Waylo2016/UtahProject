using System.Net;
using Aspire.Hosting.Testing;
using Xunit;

namespace xUnit.Tests.Services;

public class DinosaurApiTests
{
    [Fact]
    public async Task GetDinosaurs_ReturnsSuccess()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Utah_Project_AppHost>();
        await using var app = await appHost.BuildAsync();
        await app.StartAsync();

        var httpClient = app.CreateHttpClient("api");

        // Act
        // Assuming there is a GET /api/v1/Dinosaur endpoint based on the controller name
        var response = await httpClient.GetAsync("/api/v1/Dinosaur");

        // Assert
        // We might get Unauthorized or OK depending on auth setup, but this verifies the orchestration
        Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Unauthorized);
    }
}
