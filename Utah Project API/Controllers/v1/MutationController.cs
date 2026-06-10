using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utah_Project_API.Interfaces;
using Utah_Project_API.Models;

namespace Utah_Project_API.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class MutationController(IMutationService mutationService) : ControllerBase
{
    
    /// <summary>
    /// gets all species.
    /// </summary>
    /// <returns>list of all mutations</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Mutation_Lib>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Mutation_Lib>>> GetMutations()
    {
        List<Mutation_Lib> mutations = await mutationService.GetMutations();
        return Ok(mutations);   
    }
}