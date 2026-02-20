using Utah_Project_API.Models;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class MutationTestHelper
{
    public static List<Mutation_Lib> GetFakeMutations()
    {
        return
        [
            new Mutation_Lib { MutationCode = "M1", MutationName = "Fast Growth", MutationDescription = "Grows 2x faster" },
            new Mutation_Lib { MutationCode = "M2", MutationName = "Hardened Skin", MutationDescription = "Takes less damage" }
        ];
    }

    public static List<Dino_Mutation> GetFakeDinoMutations()
    {
        return
        [
            new Dino_Mutation { DinoCode = 1, MutationCode = "M1", MutationName = "Fast Growth" }
        ];
    }

    public static List<Nesting_Mutation> GetFakeNestingMutations()
    {
        return
        [
            new Nesting_Mutation { NestingId = 1, MutationCode = "M1", MutationName = "Fast Growth", MutationChance = 0.5f }
        ];
    }
}
