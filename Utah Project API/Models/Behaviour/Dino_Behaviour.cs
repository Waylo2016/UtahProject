using System.Collections.Generic;
using System.Text.Json.Serialization;
using DinoModel = Utah_Project_API.Models.Dinosaur.Dinosaur;

namespace Utah_Project_API.Models;

public class Dino_Behaviour
{
    public int DinoCode { get; set; }
    
    [JsonIgnore]
    public DinoModel Dinosaur { get; set; }
    
    public string BehaviourCode { get; set; }
    
    [JsonIgnore]
    public Behaviour_Lib Behaviour { get; set; }
}