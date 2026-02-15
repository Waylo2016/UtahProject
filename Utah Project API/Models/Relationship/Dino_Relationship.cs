using Utah_Project_API.Enums;

namespace Utah_Project_API.Models;

public class Dino_Relationship
{
    public int DinoCode { get; set; }
    
    public int TargetDinoCode { get; set; }
    
    public int RelationTypeId { get; set; }
    
    public string? CustomBondLabel { get; set; }
    
    public Dinosaur.Dinosaur? Dino { get; set; }
    
    public Dinosaur.Dinosaur? TargetDino { get; set; }
    
    public Relation_Type? RelationType { get; set; }
}