using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UtahProject.Api.DTO.User;

namespace UtahProject.Api.Interfaces;

public interface IUserService
{
    Task<GetUserDto> registerUser(CreateUserDto createUserDto);
}