using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models.Dinosaur;

public class Dinosaur
{
    public int DinoCode { get; set; }
    
    public required string UserId { get; set; }
    
    [JsonIgnore]
    public User? User { get; set; }
    
    public string DinoName { get; set; }
    
    public string Color { get; set; }
    
    public int SpeciesId { get; set; }
    
    public string? Picture { get; set; }
    
    [JsonIgnore]
    public Species Species { get; set; }
    
    [JsonIgnore]
    public ICollection<Dino_Mutation> DinoMutations { get; set; } = new List<Dino_Mutation>();
    
    [JsonIgnore]
    public ICollection<Dino_Relationship> DinoRelationships { get; set; } = new List<Dino_Relationship>();
    
    [JsonIgnore]
    public ICollection<Dino_Behaviour> DinoBehaviours { get; set; } = new List<Dino_Behaviour>();

    [JsonIgnore]
    public ICollection<Nesting_Lib> NestingsAsParent1 { get; set; } = new List<Nesting_Lib>();

    [JsonIgnore]
    public ICollection<Nesting_Lib> NestingsAsParent2 { get; set; } = new List<Nesting_Lib>();

    [JsonIgnore]
    public int? NestId { get; set; }

    [JsonIgnore]
    public Nesting_Lib? Nest { get; set; }
    
}