using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Utah_Project_API.DTO.DinoMutations;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Services;

public class MutationService : IMutationService
{
    public Task<List<Species>> GetMutations()
    {
        throw new System.NotImplementedException();
    }

    public Task<Species> GetMutationById(int mutationId)
    {
        throw new System.NotImplementedException();
    }

    public Task<Species> CreateMutation(CreateMutationDto mutationDto)
    {
        throw new System.NotImplementedException();
    }

    public Task<Species> UpdateMutation(int speciesId, JsonPatchDocument<UpdateMutationsDto> patchDoc)
    {
        throw new System.NotImplementedException();
    }

    public Task<Species> DeleteMutation(int speciesId)
    {
        throw new System.NotImplementedException();
    }
}