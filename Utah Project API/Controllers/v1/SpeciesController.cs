using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Utah_Project_API.DTO.Species;
using Utah_Project_API.Exceptions;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class SpeciesController(ISpeciesService dinosaurServiceService) : ControllerBase
{
    
    /// <summary>
    /// get all species
    /// </summary>
    /// <returns>list of species</returns>    
    [HttpGet]
    [ProducesResponseType(typeof(List<Species>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Species>>> GetSpecies()
    {
        List<Species> species = await dinosaurServiceService.GetAllSpecies();
        return Ok(species);
    }
    
    /// <summary>
    /// get species by id
    /// </summary>
    /// <param name="id">the species id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Species), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]   
    public async Task<ActionResult<Species>> GetSpeciesById(int id)
    {
        try
        {
            Species species = await dinosaurServiceService.GetSpeciesById(id);
            return Ok(species);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    /// <summary>
    /// create a new species
    /// </summary>
    /// <param name="species">Json Patch Document</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(Species), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]  
    public async Task<ActionResult<Species>> CreateSpecies([FromBody]CreateSpeciesDTO species)
    {
        try
        {
            Species newSpecies = await dinosaurServiceService.CreateSpecies(species);
            return CreatedAtAction(
                actionName: nameof(GetSpeciesById),
                routeValues: new { id = newSpecies.SpeciesId, version = "1.0" },
                value: newSpecies
            );
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// update a species
    /// </summary>
    /// <param name="speciesCode"></param>
    /// <param name="speciesPatch">Json Patch Document</param>
    /// <returns></returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(typeof(Species), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Species>> UpdateSpecies(int speciesCode, 
        [FromBody]JsonPatchDocument<SpeciesDTO> speciesPatch)
    {
        try
        {
            Species updatedSpecies = await dinosaurServiceService.UpdateSpecies(speciesCode, speciesPatch);
            return Ok(updatedSpecies);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
    /// <summary>
    /// delete a species
    /// </summary>
    /// <param name="speciesCode"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Species), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Species>> DeleteSpecies(int speciesCode)
    {
        try
        {
            Species deletedSpecies = await dinosaurServiceService.DeleteSpecies(speciesCode);
            return Ok(deletedSpecies);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}