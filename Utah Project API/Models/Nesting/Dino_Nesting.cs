using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Nesting
{
    public int dinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur Dinosaur { get; set; }
    
    public int nestingId { get; set; }
    
    [JsonIgnore]
    public Nesting_Lib nesting { get; set; }
}