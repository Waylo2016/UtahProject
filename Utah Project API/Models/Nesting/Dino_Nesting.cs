using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Nesting
{
    public int DinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur Dinosaur { get; set; }
    
    public int NestingId { get; set; }
    
    [JsonIgnore]
    public Nesting_Lib Nesting { get; set; }
}