using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Utah_Project_API.DTO.Dinosaur;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Interfaces;

public interface IDinosaurService
{
    /// <summary>
    /// Retrieves a list of all dinosaurs.
    /// </summary>
    /// <returns>A list of all dinosaurs</returns>
    Task<List<Dinosaur>> GetAllDinosaurs();
    
    /// <summary>
    /// gets a specific dinosaur by its numerical code.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <returns></returns>
    Task<Dinosaur> GetDinosaurById(int dinoCode);

    /// <summary>
    /// gets all dinosaurs owned by a specific user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userId">the id of the user whose dinosaurs are being retrieved</param>
    /// <returns>a list of dinosaurs owned by the specified user</returns>
    Task<List<Dinosaur>> GetAllDinosaursUser(ClaimsPrincipal user);

    /// <summary>
    /// Create a new dinosaur.
    /// </summary>
    /// <param name="dinosaurData">data used to create a Dinosaur</param>
    /// <param name="user"></param>
    /// <returns>The created dinosaur.</returns>
    Task<Dinosaur> CreateDinosaur(DinosaurDto dinosaurData, ClaimsPrincipal user);

    /// <summary>
    /// updates an existing dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="patchDoc"></param>
    /// <param name="dinosaurData">data used to update a dinosaur</param>
    /// <returns>the updated dinosaur</returns>
    Task<Dinosaur> PatchDinosaur(int dinoCode, JsonPatchDocument<DinosaurDto> patchDoc);

    /// <summary>
    /// deletes a dinosaur by its numerical code.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <returns>the deleted dinosaur</returns>
    Task<Dinosaur> DeleteDinosaur(ClaimsPrincipal user, int dinoCode);
    
    
    /// <summary>
    /// adds a behavior to a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="behaviourId">numerical id of a behaviour</param>
    /// <returns>the updated dinosaur with the added behaviour</returns>
    Task<Dinosaur> AddBehaviourToDinosaur(int dinoCode, int behaviourId);
    
    /// <summary>
    /// removes a behavior from a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="behaviourId">numerical id of a behaviour</param>
    /// <returns>the updated dinosaur with the removed behaviour</returns>
    Task<Dinosaur> RemoveBehaviourFromDinosaur(int dinoCode, int behaviourId);
    
    /// <summary>
    /// add a nest to a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="nestingId">numerical id of a nest</param>
    /// <returns>the updated dinosaur with the added nest</returns>
    Task<Dinosaur> AddNestToDinosaur(int dinoCode, int nestingId);
    
    /// <summary>
    /// removes a nest from a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="nestingId">numerical id of a nest</param>
    /// <returns>the updated dinosaur with the removed nest</returns>
    Task<Dinosaur> RemoveNestFromDinosaur(int dinoCode, int nestingId);
    
    /// <summary>
    /// add a mutation to a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="mutationId">numerical id of a mutation</param>
    /// <returns>the updated dinosaur with the added mutation</returns>
    Task<Dinosaur> AddMutationToDinosaur(int dinoCode, int mutationId);
        
    /// <summary>
    /// removes a mutation from a dinosaur.
    /// </summary>
    /// <param name="dinoCode">numerical code of a dinosaur</param>
    /// <param name="mutationId">numerical id of a mutation</param>
    /// <returns>the updated dinosaur with the removed mutation</returns>
    Task<Dinosaur> RemoveMutationFromDinosaur(int dinoCode, int mutationId);
    
    
    ///<summary>
    /// creates children for a dinosaur.
    /// </summary>
    /// <param name="childrenData">data used to create the children</param>
    /// <returns>the updated dinosaur with the created children</returns>
    Task<Dinosaur> CreateChildrenForDinosaur(DinoChildrenDto childrenData); // ooh yeah they fucked!! they did the oinky sploinky!! the freaky deaky!! the dirty wirty!! the nasty pasty!! the funky monkey!! the dirty wirty!! the nasty pasty!!
}