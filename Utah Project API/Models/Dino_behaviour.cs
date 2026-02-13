using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_behaviour
{
    public int dinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur dinosaur { get; set; }
    
    public string behaviourCode { get; set; }
    
    [JsonIgnore]
    public Behaviour_lib behaviour { get; set; }
}