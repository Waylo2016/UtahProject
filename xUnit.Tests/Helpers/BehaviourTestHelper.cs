using Utah_Project_API.Models;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class BehaviourTestHelper
{
    public static List<Behaviour_Lib> GetFakeBehaviours()
    {
        return
        [
            new Behaviour_Lib { BehaviourCode = "B1", BehaviourName = "Aggressive", BehaviourDescription = "Attacks on sight" },
            new Behaviour_Lib { BehaviourCode = "B2", BehaviourName = "Docile", BehaviourDescription = "Friendly" }
        ];
    }

    public static List<Dino_Behaviour> GetFakeDinoBehaviours()
    {
        return
        [
            new Dino_Behaviour { DinoCode = 1, BehaviourCode = "B1" }
        ];
    }
}
