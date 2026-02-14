using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Dino_Mutation
{
    public int dinoCode { get; set; }
    
    [JsonIgnore]
    public Dinosaur.Dinosaur dinosaur { get; set; }
    
    public string mutationCode { get; set; }
    
    [JsonIgnore]
    public Mutation_Lib Mutation { get; set; }
    
    public string mutationName { get; set; }
}