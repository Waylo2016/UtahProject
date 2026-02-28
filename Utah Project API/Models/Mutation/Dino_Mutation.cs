using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Mutation
{
    public int DinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur Dinosaur { get; set; }
    
    public string MutationCode { get; set; }
    
    [JsonIgnore]
    public Mutation_Lib Mutation { get; set; }
    
    public string MutationName { get; set; }
}