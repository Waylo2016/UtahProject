using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Utah_Project_API.Data;
using Utah_Project_API.DTO.Species;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Services;

public class SpeciesService(
    ApplicationDbContext context, 
    UserManager<User> userManager
    ) :ISpeciesService
{
    
    /// <summary>
    /// gets all species.
    /// </summary>
    /// <returns>all species</returns>
    public async Task<List<Species>> GetAllSpecies()
    {
        List<Species> species = await context.Species.ToListAsync();
        return species;
    }
    
    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="speciesId">the species id</param>
    /// <returns>a specific species</returns>
    /// <exception cref="NotFoundException">thrown when species not found</exception>
    public async Task<Species> GetSpeciesById(int speciesId)
    {
        Species? species = await context.Species.FirstOrDefaultAsync(s => s.SpeciesId == speciesId);
        if (species == null)        {
            throw new NotFoundException("Species not found.");
        }
        return species;
    }
    
    /// <summary>
    /// creates a new species.
    /// </summary>
    /// <param name="speciesData">Species data DTO</param>
    /// <returns> an OK</returns>
    public async Task<Species> CreateSpecies(CreateSpeciesDTO speciesData)
    {
        Species newSpecies = new Species
        {
            SpeciesName = speciesData.speciesName,
            SpeciesDescription = speciesData.speciesDescription
        };
        
        context.Species.Add(newSpecies);
        await context.SaveChangesAsync();
        
        return newSpecies;
    }
    /// <summary>
    /// partially updates an existing species via JSON Patch.
    /// </summary>
    /// <param name="speciesId">The id of a species</param>
    /// <param name="patchDoc">JSON Patch document</param>
    /// <returns>the updated species</returns>
    /// <exception cref="NotFoundException">thrown when species not found</exception>
    public async Task<Species> UpdateSpecies(int speciesId, JsonPatchDocument<SpeciesDTO> patchDoc)
    {
        Species species = await GetSpeciesById(speciesId);
        if (species == null)
        {
            throw new NotFoundException($"Species not found");
        }

        SpeciesDTO speciesToPath = new SpeciesDTO
        {
            speciesName = species.SpeciesName,
            speciesDescription = species.SpeciesDescription
        };
        
        patchDoc.ApplyTo(speciesToPath);
        
        species.SpeciesName = speciesToPath.speciesName;
        species.SpeciesDescription = speciesToPath.speciesDescription;
        
        await context.SaveChangesAsync();
        
        return species;
    }

    
    /// <summary>
    /// deletes a species.
    /// </summary>
    /// <param name="speciesId">The id of a species</param>
    /// <returns>he gone</returns>
    /// <exception cref="NotFoundException">thrown when species not found</exception>
    public async Task<Species> DeleteSpecies(int speciesId)
    {
        Species species = await GetSpeciesById(speciesId);
        if (species == null)
        {
            throw new NotFoundException($"Species not found.");
        }
        
        context.Species.Remove(species);
        await context.SaveChangesAsync();
        
        return species;
    }
}