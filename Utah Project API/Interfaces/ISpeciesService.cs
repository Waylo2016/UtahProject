using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Utah_Project_API.DTO.Species;
using Utah_Project_API.Models;

namespace Utah_Project_API.Interfaces;

public interface ISpeciesService
{
    /// <summary>
    /// Retrieves a list of all species.
    /// </summary>
    /// <returns>a list of species.</returns>
    Task<List<Species>> GetAllSpecies();
    
    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="speciesId">the numerical id of the species being retrieved</param>
    /// <returns>the species with the specified id</returns>
    Task<Species> GetSpeciesById(int speciesId);
    
    /// <summary>
    /// Create a new species.
    /// </summary>
    /// <param name="speciesData">data used to create a species</param>
    /// <returns>The created species.</returns>
    Task<Species> CreateSpecies(int speciesId, string speciesName);
    
    /// <summary>
    /// updates an existing species.
    /// </summary>
    /// <param name="speciesId">numerical id of a species</param>
    /// <param name="speciesData">data used to update a species</param>
    /// <returns>the updated species</returns>
    Task<Species> UpdateSpecies(int speciesId, PatchDto speciesData);
    
    /// <summary>
    /// deletes an existing species.
    /// </summary>
    /// <param name="speciesId">numerical id of a species</param>
    /// <returns>the deleted species</returns>
     Task<Species> DeleteSpecies(int speciesId);
}