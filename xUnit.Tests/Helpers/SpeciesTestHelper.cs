using Utah_Project_API.Models;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class SpeciesTestHelper
{
    public static List<Species> GetFakeSpecies()
    {
        return
        [
            new Species { SpeciesId = 1, SpeciesName = "Tyrannosaurus Rex", SpeciesDescription = "Apex predator" },
            new Species { SpeciesId = 2, SpeciesName = "Triceratops", SpeciesDescription = "Three-horned face" }
        ];
    }
}
