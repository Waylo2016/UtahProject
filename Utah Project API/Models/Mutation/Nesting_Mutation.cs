using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Nesting_Mutation
{
    public int NestingId { get; set; }
    
    [JsonIgnore]
    public Nesting_Lib Nesting { get; set; }
    
    public string MutationName { get; set; }
    
    public string MutationCode { get; set; }
    
    [JsonIgnore]
    public Mutation_Lib Mutation { get; set; }
    
    public float MutationChance { get; set; }
}