using Microsoft.AspNetCore.Identity;

namespace UtahProject.Api.Models;

public class UserModel : IdentityUser
{
    public string DinoOwner { get; set; }
}