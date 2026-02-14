using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Behaviour
{
    public int dinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur dinosaur { get; set; }
    
    public string behaviourCode { get; set; }
    
    [JsonIgnore]
    public Behaviour_Lib Behaviour { get; set; }
}