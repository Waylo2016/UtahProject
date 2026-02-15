using System.Collections.Generic;
using System.Threading.Tasks;
using Utah_Project_API.Models;

namespace Utah_Project_API.Interfaces;

public interface IMutation
{
    
    /// <summary>
    /// gets all species.
    /// </summary>
    /// <returns></returns>
    Task<List<Species>> GetSpecies();
    
    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="speciesId">the numerical id of the species being retrieved</param>
    /// <returns>the species with the specified id</returns>
    Task<Species> GetSpeciesById(int speciesId);
        
    /// <summary>
    /// creates a new species
    /// </summary>
    /// <param name="speciesData"></param>
    /// <returns>returns the newly created species</returns>
    // Task<Species> CreateSpecies(SpeciesDto speciesData);
        
    /// <summary>
    /// updates an existing species.
    /// </summary>
    /// <param name="speciesId"></param>
    /// <param name="speciesData"></param>
    /// <returns>updates a species</returns>
    // Task<Species> UpdateSpecies(int speciesId, SpeciesDto speciesData);
        
    /// <summary>
    /// deletes an existing species.
    /// </summary>
    /// <param name="speciesId"></param>
    /// <returns>deletes a species</returns>
    Task<Species> DeleteSpecies(int speciesId);
}