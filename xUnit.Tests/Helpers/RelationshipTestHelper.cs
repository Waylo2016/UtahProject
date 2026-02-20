using Utah_Project_API.Models;
using Utah_Project_API.Enums;
using System.Collections.Generic;

namespace xUnit.Tests.Helpers;

public static class RelationshipTestHelper
{
    public static List<Relation_Type> GetFakeRelationTypes()
    {
        return
        [
            new Relation_Type { Id = 1, RelationTypes = RelationTypes.Parent },
            new Relation_Type { Id = 2, RelationTypes = RelationTypes.Offspring },
            new Relation_Type { Id = 3, RelationTypes = RelationTypes.Mate }
        ];
    }

    public static List<Dino_Relationship> GetFakeDinoRelationships()
    {
        return
        [
            new Dino_Relationship { DinoCode = 1, TargetDinoCode = 2, RelationTypeId = 3 }
        ];
    }
}
