using System;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UtahProject.Api.Data;
using UtahProject.Api.DTO.User;
using UtahProject.Api.Interfaces;
using UtahProject.Api.Models;

namespace UtahProject.Api.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
public class UserController(IUserService userService
    ) : ControllerBase
{
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<GetUserDto>> registerUser([FromBody] CreateUserDto createUserDto)
    {

        GetUserDto user;

        try
        {
            user = await userService.registerUser(createUserDto);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return Ok(user);
    }

}