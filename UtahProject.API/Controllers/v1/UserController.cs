using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UtahProject.Api.Data;
using UtahProject.Api.Interfaces;
using UtahProject.Api.Models;

namespace UtahProject.Api.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("0.1")]
[Produces("application/json")]
public class UserController(IUserService userService
    ) : ControllerBase
{
    
}