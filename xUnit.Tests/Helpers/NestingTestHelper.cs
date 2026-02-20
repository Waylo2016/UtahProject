using Utah_Project_API.Models;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class NestingTestHelper
{
    public static List<Nesting_Lib> GetFakeNestings()
    {
        return
        [
            new Nesting_Lib { NestingId = 1, Parent1Code = 1, Parent2Code = 2, NestingDescription = "Cave Nest", ExtendedDesciption = "A secure cave nest" }
        ];
    }

    public static List<Dino_Nesting> GetFakeDinoNestings()
    {
        return
        [
            new Dino_Nesting { DinoCode = 1, NestingId = 1 },
            new Dino_Nesting { DinoCode = 2, NestingId = 1 }
        ];
    }
}
