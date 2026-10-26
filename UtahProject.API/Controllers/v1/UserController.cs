using Asp.Versioning;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UtahProject.Api.Data;
using UtahProject.Api.Models;

namespace UtahProject.Api.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("0.1")]
[Produces("application/json")]
public class UserController(ApplicationDbContext context,
    UserManager<UserModel> userManager,
    SignInManager<UserModel> signInManager
    ) : ControllerBase
{
    
}