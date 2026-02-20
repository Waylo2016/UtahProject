using Utah_Project_API.Models.Dinosaur;
using Utah_Project_API.Enums;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class DinosaurTestHelper
{
    public static List<Dinosaur> GetFakeDinosaurs()
    {
        return
        [
            new Dinosaur { DinoCode = 1, DinoName = "Rexy", UserId = "user-1", SpeciesId = 1, Gender = Gender.EggLayer, Color = "Brown", NestId = 1 },
            new Dinosaur { DinoCode = 2, DinoName = "Trike", UserId = "user-1", SpeciesId = 2, Gender = Gender.EggGiver, Color = "Grey", NestId = 1 },
            new Dinosaur { DinoCode = 3, DinoName = "Blue", UserId = "user-2", SpeciesId = 1, Gender = Gender.Asexual, Color = "Blue" }
        ];
    }
}
