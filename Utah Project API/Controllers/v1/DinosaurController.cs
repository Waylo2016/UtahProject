using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Utah_Project_API.DTO.Dinosaur;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class DinosaurController(IDinosaurService dinosaurServiceService) : ControllerBase
{
    /// <summary>
    /// get all dinosaurs
    /// </summary>
    /// <returns>list of dinosaurs</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Dinosaur>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Dinosaur>>> GetAllDinosaurs()
    {
        List<Dinosaur> dinosaurs = await dinosaurServiceService.GetAllDinosaurs();
        return Ok(dinosaurs);
    }

    /// <summary>
    /// get dinosaur by id
    /// </summary>
    /// <param name="dinoCode">dinosaur code</param>
    /// <returns>dinosaur with the given id</returns>
    [HttpGet("{dinoCode:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> GetDinosaurById(int dinoCode)
    {
        try
        {
            Dinosaur dinosaur = await dinosaurServiceService.GetDinosaurById(dinoCode);
            return Ok(dinosaur);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// get all dinosaurs for a user
    /// </summary>
    /// <returns>list of dinosaurs for a user</returns>
    [HttpGet("DinoUser")]
    [ProducesResponseType(typeof(List<Dinosaur>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Dinosaur>>> GetAllDinosaursUser()
    {
        try
        {
            List<Dinosaur> dinosaurs = await dinosaurServiceService.GetAllDinosaursUser(User);
            return Ok(dinosaurs);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Creates new dinosaur
    /// </summary>
    /// <param name="dinosaurData"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Dinosaur>> CreateDinosaur([FromBody] DinosaurDto dinosaurData)
    {
        try
        {
            Dinosaur created = await dinosaurServiceService.CreateDinosaur(dinosaurData, User);
            return CreatedAtAction(
                actionName: nameof(GetDinosaurById),
                routeValues: new { dinoCode = created.DinoCode, version = "1.0" },
                value: created
            );
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }

    /// <summary>
    /// Updates data in the dinosaur with the given id.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="patchDoc"></param>
    /// <returns></returns>
    [HttpPatch("{dinoCode:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> PatchDinosaur(int dinoCode,
        [FromBody] JsonPatchDocument<UpdateDinosaurDto> patchDoc)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.PatchDinosaur(dinoCode, patchDoc);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// deletes dinosaur
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <returns></returns>
    [HttpDelete("{dinoCode:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<Dinosaur>> DeleteDinosaur(int dinoCode)
    {
        try
        {
            Dinosaur deleted = await dinosaurServiceService.DeleteDinosaur(User, dinoCode);
            return Ok(deleted);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Forbid(e.Message);
        }
    }

    /// <summary>
    /// adds behaviour to a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="behaviourCode"></param>
    /// <returns></returns>
    [HttpPost("{dinoCode:int}/behaviours/{behaviourCode}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> AddBehaviourToDinosaur(int dinoCode, string behaviourCode)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.AddBehaviourToDinosaur(dinoCode, behaviourCode);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// removes a behaviour from a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="behaviourId"></param>
    /// <returns></returns>
    [HttpDelete("{dinoCode:int}/behaviours/{behaviourId:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> RemoveBehaviourFromDinosaur(int dinoCode, int behaviourId)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.RemoveBehaviourFromDinosaur(dinoCode, behaviourId);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// adds a nest to a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="nestingId"></param>
    /// <returns></returns>
    [HttpPost("{dinoCode:int}/nests/{nestingId:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> AddNestToDinosaur(int dinoCode, int nestingId)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.AddNestToDinosaur(dinoCode, nestingId);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// removes a nest from a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="nestingId"></param>
    /// <returns></returns>
    [HttpDelete("{dinoCode:int}/nests/{nestingId:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> RemoveNestFromDinosaur(int dinoCode, int nestingId)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.RemoveNestFromDinosaur(dinoCode, nestingId);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// adds a mutation to a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="mutationCode"></param>
    /// <returns></returns>
    [HttpPost("{dinoCode:int}/mutations/{mutationCode}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> AddMutationToDinosaur(int dinoCode, string mutationCode)
    {
        try
        {
            Dinosaur updated = await dinosaurServiceService.AddMutationToDinosaur(dinoCode, mutationCode);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    /// <summary>
    /// removes a mutation from a dinosaur.
    /// </summary>
    /// <param name="dinoCode"></param>
    /// <param name="mutationId"></param>
    /// <returns></returns>
    [HttpDelete("{dinoCode:int}/mutations/{mutationId:int}")]
    [ProducesResponseType(typeof(Dinosaur), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Dinosaur>> RemoveMutationFromDinosaur(int dinoCode, int mutationId)
    {
        try
        {            
            Dinosaur updated = await dinosaurServiceService.RemoveMutationFromDinosaur(dinoCode, mutationId);
            return Ok(updated);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// adds a child to a dinosaur
    /// </summary>
    /// <param name="childrenData"></param>
    /// <returns></returns>
    [HttpPost("children")]
    [ProducesResponseType(typeof(List<Dinosaur>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<Dinosaur>>> CreateChildrenForDinosaur([FromBody] DinoChildrenDto childrenData)
    {
        try
        {
            Dinosaur createdChildren = await dinosaurServiceService.CreateChildrenForDinosaur(childrenData);
            return Ok(createdChildren);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}