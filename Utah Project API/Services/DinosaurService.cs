using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Utah_Project_API.Data;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Services;

public class DinosaurService(
    ApplicationDbContext context
    ) : IDinosaurService
{
    public async Task<List<Dinosaur>> GetAllDinosaurs()
    {
        List<Dinosaur> dinosaurs = await context.Dinosaurs.ToListAsync();
        
        return dinosaurs;
    }

    public async Task<Dinosaur> GetDinosaurById(int dinoCode)
    {
        Dinosaur? dinosaur = await context.Dinosaurs.FirstOrDefaultAsync(d => d.DinoCode == dinoCode);
        if (dinosaur == null)
        {
            throw new NotFoundException("Dinosaur not found");
        }

        return dinosaur;
    }

    public async Task<Dinosaur> GetAllDinosaursUser(string userId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> DeleteDinosaur(string userId, int dinoCode)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> AddBehaviourToDinosaur(int dinoCode, int behaviourId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveBehaviourFromDinosaur(int dinoCode, int behaviourId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> AddNestToDinosaur(int dinoCode, int nestingId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveNestFromDinosaur(int dinoCode, int nestingId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> AddMutationToDinosaur(int dinoCode, int mutationId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Dinosaur> RemoveMutationFromDinosaur(int dinoCode, int mutationId)
    {
        throw new System.NotImplementedException();
    }
}