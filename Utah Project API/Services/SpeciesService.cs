using System.Collections.Generic;
using System.Threading.Tasks;
using Utah_Project_API.DTO.Species;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Services;

public class SpeciesService :ISpeciesService
{
    public async Task<List<Species>> GetAllSpecies()
    {
        throw new System.NotImplementedException();
    }

    public async Task<Species> GetSpeciesById(int speciesId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Species> CreateSpecies(int speciesId, string speciesName)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Species> UpdateSpecies(int speciesId, PatchDto speciesData)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Species> DeleteSpecies(int speciesId)
    {
        throw new System.NotImplementedException();
    }
}