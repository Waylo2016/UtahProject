using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
}