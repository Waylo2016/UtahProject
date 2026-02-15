using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Behaviour
{
    public int DinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur Dinosaur { get; set; }
    
    public string BehaviourCode { get; set; }
    
    [JsonIgnore]
    public Behaviour_Lib Behaviour { get; set; }
}