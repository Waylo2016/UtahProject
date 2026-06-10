using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Utah_Project_API.Data;
using Utah_Project_API.DTO.DinoMutations;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Services;

public class MutationService(
    ApplicationDbContext context
    ) : IMutationService
{
    
    /// <summary>
    /// gets all species.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Mutation_Lib>> GetMutations()
    {
        List<Mutation_Lib> mutation = await context.Mutations.ToListAsync();
        return mutation;
    }

    /// <summary>
    /// gets a specific species by its numerical id.
    /// </summary>
    /// <param name="mutationId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Mutation_Lib> GetMutationById(int mutationId)
    {
        Mutation_Lib mutation = await context.Mutations.FindAsync(mutationId);
        if (mutation == null)
        {
            throw new NotFoundException("Mutation not found.");
        }
        
        return mutation;
    }

    /// <summary>
    /// creates a new species.
    /// </summary>
    /// <param name="mutationDto">DTO data</param>
    /// <returns></returns>
    public async Task<Mutation_Lib> CreateMutation(CreateMutationDto mutationDto)
    {
        Mutation_Lib newMutation = new Mutation_Lib
        {
            MutationName = mutationDto.MutationName,
            MutationDescription = mutationDto.MutationDescription
        };
        
        context.Mutations.Add(newMutation);
        await context.SaveChangesAsync();
        
        return newMutation;
    }

    /// <summary>
    /// updates a mutation by its id. Only the fields provided in the patch document will be updated.
    /// </summary>
    /// <param name="mutationId">id of the mutation</param>
    /// <param name="patchDoc">patch document containing the fields to update</param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    public async Task<Mutation_Lib> UpdateMutation(int mutationId, JsonPatchDocument<UpdateMutationsDto> patchDoc)
    {
        Mutation_Lib mutation = await GetMutationById(mutationId);
        if (mutation == null)
        {
            throw new NotFoundException($"Mutation not found");
        }
        
        UpdateMutationsDto mutationToPatch = new UpdateMutationsDto
        {
            MutationName = mutation.MutationName,
            MutationDescription = mutation.MutationDescription
        };
        
        patchDoc.ApplyTo(mutationToPatch);
        
        mutation.MutationName = mutationToPatch.MutationName;
        mutation.MutationDescription = mutationToPatch.MutationDescription;
        
        await context.SaveChangesAsync();
        
        return mutation;
    }

    public async Task<Mutation_Lib> DeleteMutation(int mutationId)
    {
        Mutation_Lib mutation = await GetMutationById(mutationId);
        if (mutation == null)
        {
            throw new NotFoundException($"Mutation not found.");
        }
        
        context.Mutations.Remove(mutation);
        await context.SaveChangesAsync();
        
        return mutation;
    }
}