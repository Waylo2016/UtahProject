using System;
using Microsoft.AspNetCore.Identity;

namespace UtahProject.Api.Models;

public class UserModel : IdentityUser
{
    public Guid DinoOwner { get; set; }
}