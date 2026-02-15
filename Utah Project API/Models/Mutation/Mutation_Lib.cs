using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Utah_Project_API.Models;

public class Mutation_Lib
{
    /// <summary>
    /// Represents the unique identifier for a mutation within the mutation library.
    /// </summary>
    public string MutationCode { get; set; }
    
    /// <summary>
    /// name of the mutation
    /// </summary>
    public string MutationName { get; set; }
        
    /// <summary>
    /// description of the mutation
    /// </summary>
    public string MutationDescription { get; set; }
    
    [JsonIgnore]
    public ICollection<Dino_Mutation> DinoMutations { get; set; } = new List<Dino_Mutation>();
}
