using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Utah_Project_API.Data;
using Utah_Project_API.Models;
using System;
using System.Threading.Tasks;

namespace xUnit.Tests.Helpers;

public abstract class DinosaurServiceTestsBase : IDisposable
{
    protected readonly ApplicationDbContext Context;
    protected readonly Mock<UserManager<User>> MockUserManager;

    protected DinosaurServiceTestsBase()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Context = new ApplicationDbContext(options);
        Context.Database.EnsureCreated();

        var store = new Mock<IUserStore<User>>();
        MockUserManager = new Mock<UserManager<User>>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
    }

    protected async Task SeedDatabase()
    {
        Context.Users.AddRange(UserTestHelper.GetFakeUsers());
        Context.Species.AddRange(SpeciesTestHelper.GetFakeSpecies());
        Context.Behaviours.AddRange(BehaviourTestHelper.GetFakeBehaviours());
        Context.Mutations.AddRange(MutationTestHelper.GetFakeMutations());
        Context.RelationTypes.AddRange(RelationshipTestHelper.GetFakeRelationTypes());
        await Context.SaveChangesAsync();

        Context.Dinosaurs.AddRange(DinosaurTestHelper.GetFakeDinosaurs());
        Context.Nestings.AddRange(NestingTestHelper.GetFakeNestings());
        await Context.SaveChangesAsync();
        
        // Add links
        Context.DinoBehaviours.AddRange(BehaviourTestHelper.GetFakeDinoBehaviours());
        Context.DinoMutations.AddRange(MutationTestHelper.GetFakeDinoMutations());
        Context.NestingMutations.AddRange(MutationTestHelper.GetFakeNestingMutations());
        Context.DinoRelationships.AddRange(RelationshipTestHelper.GetFakeDinoRelationships());
        Context.DinoNestings.AddRange(NestingTestHelper.GetFakeDinoNestings());
        await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
