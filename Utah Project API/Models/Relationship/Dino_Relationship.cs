using Utah_Project_API.Enums;

namespace Utah_Project_API.Models;

public class Dino_Relationship
{
    public int dinocode { get; set; }
    
    public int targetDinocode { get; set; }
    
    public int relationTypeId { get; set; }
    
    public string? customBondLabel { get; set; }
    
    public Dinosaur.Dinosaur? Dino { get; set; }
    
    public Dinosaur.Dinosaur? TargetDino { get; set; }
    
    public Relation_Type? relationType { get; set; }
}