using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models.Dinosaur;

namespace Utah_Project_API.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class DinosaurController (IDinosaurService dinosaurServiceService) : ControllerBase
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
    
}