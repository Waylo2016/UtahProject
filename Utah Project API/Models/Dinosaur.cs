using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dinosaur
{
    public int dinoCode { get; set; }
    
    public string userId { get; set; }
    
    public string dinoName { get; set; }
    
    public string color { get; set; }
    
    public int speciesId { get; set; }
    
    [JsonIgnore]
    public Species species { get; set; }
}