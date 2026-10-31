using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtahProject.Api.DTO.User;

namespace UtahProject.Api.Interfaces;

public interface IUserService
{
    Task<ActionResult<GetUserDto>> registerUser(CreateUserDto createUserDto);
}