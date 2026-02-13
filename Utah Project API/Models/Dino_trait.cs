using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_trait
{
    public int dinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur dinosaur { get; set; }
    
    public string traitCode { get; set; }
    
    [JsonIgnore]
    public Trait_lib trait { get; set; }
    
    public string mutationName { get; set; }
}