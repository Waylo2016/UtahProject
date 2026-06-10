using System.Collections.Generic;
using System.Threading.Tasks;
using Utah_Project_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Utah_Project_API.DTO.DinoMutations;

namespace Utah_Project_API.Interfaces;

public interface IMutationService
{
    
    /// <summary>
    /// gets all species.
    /// </summary>
    /// <returns></returns>
    Task<List<Mutation_Lib>> GetMutations();
    
    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="mutationId">the numerical id of the species being retrieved</param>
    /// <returns>the species with the specified id</returns>
    Task<Mutation_Lib> GetMutationById(int mutationId);
        
    /// <summary>
    /// creates a new species
    /// </summary>
    /// <param name="mutationDto"></param>
    /// <returns>returns the newly created species</returns>
     Task<Mutation_Lib> CreateMutation(CreateMutationDto mutationDto);
        
    /// <summary>
    /// updates an existing mutation.
    /// </summary>
    /// <param name="mutation"></param>
    /// <param name="patchDoc"></param>
    /// <returns>updates a species</returns>
     Task<Mutation_Lib> UpdateMutation(int mutation, JsonPatchDocument<UpdateMutationsDto> patchDoc);
        
    /// <summary>
    /// deletes an existing mutation.
    /// </summary>
    /// <param name="mutationId"></param>
    /// <returns>deletes a species</returns>
    Task<Mutation_Lib> DeleteMutation(int mutationId);
}