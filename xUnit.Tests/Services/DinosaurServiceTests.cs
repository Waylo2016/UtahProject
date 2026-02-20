using System.Security.Claims;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Moq;
using Utah_Project_API.DTO.Dinosaur;
using Utah_Project_API.Models;
using Utah_Project_API.Models.Dinosaur;
using Utah_Project_API.Services;
using xUnit.Tests.Helpers;
using Xunit;
using Utah_Project_API.Enums;
using Utah_Project_API.Exceptions;

namespace xUnit.Tests.Services;

public class DinosaurServiceTests : DinosaurServiceTestsBase
{
    private readonly DinosaurService _service;

    public DinosaurServiceTests()
    {
        _service = new DinosaurService(Context, MockUserManager.Object);
    }

    [Fact]
    public async Task GetAllDinosaurs_ReturnsAllDinosaurs()
    {
        // Arrange
        await SeedDatabase();

        // Act
        var result = await _service.GetAllDinosaurs();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, d => d.DinoName == "Rexy");
    }

    [Fact]
    public async Task GetDinosaurById_ExistingId_ReturnsDinosaur()
    {
        // Arrange
        await SeedDatabase();

        // Act
        var result = await _service.GetDinosaurById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Rexy", result.DinoName);
    }

    [Fact]
    public async Task GetDinosaurById_NonExistingId_ThrowsNotFoundException()
    {
        // Arrange
        await SeedDatabase();

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetDinosaurById(999));
    }

    [Fact]
    public async Task GetAllDinosaursUser_ReturnsUserDinosaurs()
    {
        // Arrange
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user-1")
        }));

        // Act
        var result = await _service.GetAllDinosaursUser(user);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.All(result, d => Assert.Equal("user-1", d.UserId));
    }

    [Fact]
    public async Task CreateDinosaur_ValidData_ReturnsCreatedDinosaur()
    {
        // Arrange
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        var userEntity = Context.Users.First(u => u.Id == "user-1");
        MockUserManager.Setup(um => um.GetUserAsync(user)).ReturnsAsync(userEntity);

        var dto = new DinosaurDto
        {
            DinoName = "Blue",
            Color = "Blue",
            SpeciesId = 1,
            Picture = "",
            gender = Gender.EggLayer
        };

        // Act
        var result = await _service.CreateDinosaur(dto, user);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Blue", result.DinoName);
        Assert.Equal("user-1", result.UserId);
        Assert.Equal(4, Context.Dinosaurs.Count());
    }

    [Fact]
    public async Task DeleteDinosaur_ExistingDinosaur_RemovesDinosaur()
    {
        // Arrange
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "user-1")
        }));

        // Remove required relationships that would block deletion in this test
        var relsFrom = Context.DinoRelationships.Where(r => r.DinoCode == 1).ToList();
        var relsTo = Context.DinoRelationships.Where(r => r.TargetDinoCode == 1).ToList();
        Context.DinoRelationships.RemoveRange(relsFrom);
        Context.DinoRelationships.RemoveRange(relsTo);
        await Context.SaveChangesAsync();

        // Act
        var result = await _service.DeleteDinosaur(user, 1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, Context.Dinosaurs.Count());
    }

    [Fact]
    public async Task AddBehaviourToDinosaur_ValidBehaviour_AddsBehaviour()
    {
        // Arrange
        await SeedDatabase();
        // Create the link entity expected by the service
        if (await Context.DinoBehaviours.FindAsync(1, "B1") == null)
        {
            Context.DinoBehaviours.Add(new Dino_Behaviour { DinoCode = 1, BehaviourCode = "B1" });
            await Context.SaveChangesAsync();
        }

        // Clear tracking to avoid issues with collection in memory
        Context.ChangeTracker.Clear();

        // Act
        var result = await _service.AddBehaviourToDinosaur(1, "B1");

        // Assert
        Assert.Contains(result.DinoBehaviours, db => db.BehaviourCode == "B1");
    }

    [Fact]
    public async Task AddMutationToDinosaur_ValidMutation_AddsMutation()
    {
        // Arrange
        await SeedDatabase();
        var dinosaur = await Context.Dinosaurs.FindAsync(1);
        dinosaur.NestId = 1;
        await Context.SaveChangesAsync();
        
        // Ensure no pre-existing mutation with the same key is tracked
        var preExisting = Context.DinoMutations.Where(dm => dm.DinoCode == 1 && dm.MutationCode == "M1").ToList();
        if (preExisting.Any())
        {
            Context.DinoMutations.RemoveRange(preExisting);
            await Context.SaveChangesAsync();
        }
        Context.ChangeTracker.Clear();

        // Act
        var result = await _service.AddMutationToDinosaur(1, "M1");

        // Assert
        Assert.Single(result.DinoMutations);
        Assert.Equal("M1", result.DinoMutations.First().MutationCode);
    }
    [Fact]
    public async Task PatchDinosaur_ValidPatch_UpdatesDinosaur()
    {
        // Arrange
        await SeedDatabase();
        var patchDoc = new JsonPatchDocument<UpdateDinosaurDto>();
        patchDoc.Replace(d => d.DinoName, "New Name");

        // Act
        var result = await _service.PatchDinosaur(1, patchDoc);

        // Assert
        Assert.Equal("New Name", result.DinoName);
        var updatedDino = await Context.Dinosaurs.FindAsync(1);
        Assert.Equal("New Name", updatedDino.DinoName);
    }

    [Fact]
    public async Task RemoveBehaviourFromDinosaur_ExistingBehaviour_RemovesBehaviour()
    {
        // Arrange
        await SeedDatabase();
        // Ensure behaviour lib with code "10" exists
        if (await Context.Behaviours.FindAsync("10") == null)
        {
            Context.Behaviours.Add(new Behaviour_Lib { BehaviourCode = "10", BehaviourName = "Test", BehaviourDescription = "Test" });
            await Context.SaveChangesAsync();
        }
        // Ensure only this link exists for the test
        var existingLinks = Context.DinoBehaviours.Where(db => db.DinoCode == 1).ToList();
        Context.DinoBehaviours.RemoveRange(existingLinks);
        Context.DinoBehaviours.Add(new Dino_Behaviour { DinoCode = 1, BehaviourCode = "10" });
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();

        // Act
        var result = await _service.RemoveBehaviourFromDinosaur(1, 10);

        // Assert
        Assert.Empty(result.DinoBehaviours);
    }

    [Fact]
    public async Task AddNestToDinosaur_ValidNest_SetsNestId()
    {
        // Arrange
        await SeedDatabase();
        if (await Context.Nestings.FindAsync(101) == null)
        {
            Context.Nestings.Add(new Nesting_Lib { NestingId = 101, Parent1Code = 1, Parent2Code = 2, NestingDescription = "Test Nest", ExtendedDesciption = "Test" });
        }
        if (await Context.DinoNestings.FindAsync(1, 101) == null)
        {
            Context.DinoNestings.Add(new Dino_Nesting { DinoCode = 1, NestingId = 101 });
        }
        await Context.SaveChangesAsync();

        // Act
        var result = await _service.AddNestToDinosaur(1, 101);

        // Assert
        Assert.Equal(101, result.NestId);
    }

    [Fact]
    public async Task RemoveNestFromDinosaur_ExistingNest_ClearsNestId()
    {
        // Arrange
        await SeedDatabase();
        var dino = await Context.Dinosaurs.FindAsync(1);
        dino.NestId = 101;
        if (await Context.Nestings.FindAsync(101) == null)
        {
            Context.Nestings.Add(new Nesting_Lib { NestingId = 101, Parent1Code = 1, Parent2Code = 2, NestingDescription = "Test Nest", ExtendedDesciption = "Test" });
        }
        if (await Context.DinoNestings.FindAsync(1, 101) == null)
        {
            Context.DinoNestings.Add(new Dino_Nesting { DinoCode = 1, NestingId = 101 });
        }
        await Context.SaveChangesAsync();

        // Act
        var result = await _service.RemoveNestFromDinosaur(1, 101);

        // Assert
        Assert.Null(result.NestId);
    }

    [Fact]
    public async Task RemoveMutationFromDinosaur_ExistingMutation_RemovesMutation()
    {
        // Arrange
        await SeedDatabase();
        // Ensure only one dino mutation with code "10" exists for the test
        var existingMuts = Context.DinoMutations.Where(dm => dm.DinoCode == 1).ToList();
        Context.DinoMutations.RemoveRange(existingMuts);
        Context.DinoMutations.Add(new Dino_Mutation { DinoCode = 1, MutationCode = "10", MutationName = "Test" });
        await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();

        // Act
        var result = await _service.RemoveMutationFromDinosaur(1, 10);

        // Assert
        Assert.Empty(result.DinoMutations);
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_ValidData_CreatesChildDino()
    {
        // Arrange
        await SeedDatabase();
        // Ensure required relation types exist are already seeded in base
        var dto = new DinoChildrenDto
        {
            parent1Code = 1,
            parent2Code = 2,
            Name = "Junior",
            Species = 1,
            Gender = (int)Gender.Asexual,
            Color = "Mixed"
        };

        // Act
        var result = await _service.CreateChildrenForDinosaur(dto);

        // Assert
        Assert.NotNull(result);
        var child = await Context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoName == "Junior");
        Assert.NotNull(child);
        Assert.Equal(1, child.NestId);
    }

    // SAD FLOW TESTS
    [Fact]
    public async Task GetAllDinosaursUser_NoDinosaurs_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "no-dino-user")
        }));

        await Assert.ThrowsAsync<NotFoundException>(() => _service.GetAllDinosaursUser(user));
    }

    [Fact]
    public async Task CreateDinosaur_UserNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        MockUserManager.Setup(um => um.GetUserAsync(user)).ReturnsAsync((User)null!);

        var dto = new DinosaurDto
        {
            DinoName = "Ghost",
            Color = "White",
            SpeciesId = 1,
            Picture = string.Empty,
            gender = Gender.Asexual
        };

        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateDinosaur(dto, user));
    }

    [Fact]
    public async Task PatchDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var patchDoc = new JsonPatchDocument<UpdateDinosaurDto>();
        patchDoc.Replace(d => d.DinoName, "X");

        await Assert.ThrowsAsync<NotFoundException>(() => _service.PatchDinosaur(999, patchDoc));
    }

    [Fact]
    public async Task DeleteDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "user-1") }));
        await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteDinosaur(user, 999));
    }

    [Fact]
    public async Task DeleteDinosaur_UnauthorizedUser_ThrowsUnauthorizedAccessException()
    {
        await SeedDatabase();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, "user-2") }));
        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _service.DeleteDinosaur(user, 1));
    }

    [Fact]
    public async Task AddBehaviourToDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddBehaviourToDinosaur(999, "B1"));
    }

    [Fact]
    public async Task AddBehaviourToDinosaur_LinkNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddBehaviourToDinosaur(1, "B999"));
    }

    [Fact]
    public async Task RemoveBehaviourFromDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveBehaviourFromDinosaur(999, 10));
    }

    [Fact]
    public async Task RemoveBehaviourFromDinosaur_LinkNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveBehaviourFromDinosaur(1, 999));
    }

    [Fact]
    public async Task AddNestToDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddNestToDinosaur(999, 1));
    }

    [Fact]
    public async Task AddNestToDinosaur_LinkNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddNestToDinosaur(1, 999));
    }

    [Fact]
    public async Task RemoveNestFromDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveNestFromDinosaur(999, 1));
    }

    [Fact]
    public async Task RemoveNestFromDinosaur_LinkNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveNestFromDinosaur(1, 999));
    }

    [Fact]
    public async Task AddMutationToDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddMutationToDinosaur(999, "M1"));
    }

    [Fact]
    public async Task AddMutationToDinosaur_ConfigNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        // Use a dinosaur without a nest or with a code that doesn't exist in Nesting_Mutation
        await Assert.ThrowsAsync<NotFoundException>(() => _service.AddMutationToDinosaur(3, "M999"));
    }

    [Fact]
    public async Task RemoveMutationFromDinosaur_DinoNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveMutationFromDinosaur(999, 10));
    }

    [Fact]
    public async Task RemoveMutationFromDinosaur_LinkNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        await Assert.ThrowsAsync<NotFoundException>(() => _service.RemoveMutationFromDinosaur(1, 999));
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_Parent1NotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var dto = new DinoChildrenDto
        {
            parent1Code = 999,
            parent2Code = 2,
            Name = "Kid",
            Species = 1,
            Gender = (int)Gender.Asexual,
            Color = "x"
        };
        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateChildrenForDinosaur(dto));
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_Parent2NotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var dto = new DinoChildrenDto
        {
            parent1Code = 1,
            parent2Code = 999,
            Name = "Kid",
            Species = 1,
            Gender = (int)Gender.Asexual,
            Color = "x"
        };
        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateChildrenForDinosaur(dto));
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_NestNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var dto = new DinoChildrenDto
        {
            parent1Code = 1,
            parent2Code = 3, // No nest for this pair in seed
            Name = "Kid",
            Species = 1,
            Gender = (int)Gender.Asexual,
            Color = "x"
        };
        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateChildrenForDinosaur(dto));
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_SpeciesNotFound_ThrowsNotFoundException()
    {
        await SeedDatabase();
        var dto = new DinoChildrenDto
        {
            parent1Code = 1,
            parent2Code = 2,
            Name = "Kid",
            Species = 999,
            Gender = (int)Gender.Asexual,
            Color = "x"
        };
        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateChildrenForDinosaur(dto));
    }

    [Fact]
    public async Task CreateChildrenForDinosaur_RelationTypesMissing_ThrowsException()
    {
        await SeedDatabase();
        // Remove relation types to force failure
        Context.RelationTypes.RemoveRange(Context.RelationTypes);
        await Context.SaveChangesAsync();

        var dto = new DinoChildrenDto
        {
            parent1Code = 1,
            parent2Code = 2,
            Name = "Kid",
            Species = 1,
            Gender = (int)Gender.Asexual,
            Color = "x"
        };
        await Assert.ThrowsAsync<Exception>(() => _service.CreateChildrenForDinosaur(dto));
    }
}
