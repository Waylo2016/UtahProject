using Utah_Project_API.Enums;

namespace Utah_Project_API.Models;

public class Relation_Type
{
    public int relationTypeId { get; set; }
    
    public RelationTypes RelationTypes { get; set; }
}