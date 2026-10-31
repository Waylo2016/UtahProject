using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UtahProject.Api.Data;
using UtahProject.Api.DTO.User;
using UtahProject.Api.Interfaces;
using UtahProject.Api.Models;

namespace UtahProject.Api.Services;

public class UserService(
    ApplicationDbContext context,
    UserManager<UserModel> userManager,
    SignInManager<UserModel> signInManager,
    ILogger<UserService> logger
    ) : IUserService
{
    public async Task<ActionResult<GetUserDto>> registerUser(CreateUserDto createUserDto)
    {
        UserModel user = new()
        {
            Id = Guid.Empty,
            UserName = createUserDto.UserName,
            Email = createUserDto.Email,
            Dinosaurs = null
        };       
        
        var existingUser = await userManager.FindByNameAsync(createUserDto.UserName);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }
        
        
        return null;
    }

   
}