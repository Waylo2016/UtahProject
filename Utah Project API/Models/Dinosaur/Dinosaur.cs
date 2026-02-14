using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models.Dinosaur;

public class Dinosaur
{
    public int dinoCode { get; set; }
    
    public required string userId { get; set; }
    
    [JsonIgnore]
    public User? user { get; set; }
    
    public string dinoName { get; set; }
    
    public string color { get; set; }
    
    public int speciesId { get; set; }
    
    [JsonIgnore]
    public Species species { get; set; }
    
    [JsonIgnore]
    public ICollection<Dino_Mutation> dinoMutations { get; set; } = new List<Dino_Mutation>();
    
    [JsonIgnore]
    public ICollection<Dino_Relationship> dinoRelationships { get; set; } = new List<Dino_Relationship>();
    
    [JsonIgnore]
    public ICollection<Dino_Behaviour> dinoBehaviours { get; set; } = new List<Dino_Behaviour>();

    [JsonIgnore]
    public ICollection<Nesting_Lib> nestingsAsParent1 { get; set; } = new List<Nesting_Lib>();

    [JsonIgnore]
    public ICollection<Nesting_Lib> nestingsAsParent2 { get; set; } = new List<Nesting_Lib>();

    [JsonIgnore]
    public int? nestId { get; set; }

    [JsonIgnore]
    public Nesting_Lib? nest { get; set; }
    
}