using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Nesting_Mutation
{
    public int nestingId { get; set; }
    
    [JsonIgnore]
    public Nesting_Lib nesting { get; set; }
    
    public string mutationName { get; set; }
    
    public string mutationCode { get; set; }
    
    [JsonIgnore]
    public Mutation_Lib Mutation { get; set; }
    
    public float mutationChance { get; set; }
}