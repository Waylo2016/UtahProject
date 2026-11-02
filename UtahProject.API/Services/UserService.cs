using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UtahProject.Api.Data;
using UtahProject.Api.DTO.User;
using UtahProject.Api.Interfaces;
using UtahProject.Api.Models;

namespace UtahProject.Api.Services;

public class UserService(
#pragma warning disable CS9113 // Parameter is unread.
    ApplicationDbContext context,
#pragma warning restore CS9113 // Parameter is unread.
    UserManager<UserModel> userManager,
#pragma warning disable CS9113 // Parameter is unread.
    SignInManager<UserModel> signInManager,
    ILogger<UserService> logger
#pragma warning restore CS9113 // Parameter is unread.
) : IUserService
{
    public async Task<GetUserDto> registerUser(CreateUserDto createUserDto)
    {
        UserModel user = new()
        {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email
        };

        var existingUser = await userManager.FindByNameAsync(createUserDto.UserName);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var result = await userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            throw new Exception("Registration failed");
        }

        await VerifyUser(user);

        var createdUser = new GetUserDto()
        {
            Name = user.UserName,
            Email = user.Email
        };

        return createdUser;
    }


    // will change in the future, is covered by PU-14
    private async Task<UserModel> VerifyUser(UserModel user)
    {
        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);
        return user;
    }
}