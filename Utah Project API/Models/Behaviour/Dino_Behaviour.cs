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
    public ICollection<Behaviour_Lib> behaviour { get; set; } = new List<Behaviour_Lib>();
}