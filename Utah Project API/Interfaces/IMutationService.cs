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
    Task<List<Species>> GetMutations();
    
    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="mutationId">the numerical id of the species being retrieved</param>
    /// <returns>the species with the specified id</returns>
    Task<Species> GetMutationById(int mutationId);
        
    /// <summary>
    /// creates a new species
    /// </summary>
    /// <param name="mutationDto"></param>
    /// <returns>returns the newly created species</returns>
     Task<Species> CreateMutation(CreateMutationDto mutationDto);
        
    /// <summary>
    /// updates an existing species.
    /// </summary>
    /// <param name="speciesId"></param>
    /// <param name="speciesData"></param>
    /// <returns>updates a species</returns>
     Task<Species> UpdateMutation(int speciesId, JsonPatchDocument<UpdateMutationsDto> patchDoc);
        
    /// <summary>
    /// deletes an existing species.
    /// </summary>
    /// <param name="speciesId"></param>
    /// <returns>deletes a species</returns>
    Task<Species> DeleteMutation(int speciesId);
}