using Microsoft.AspNetCore.Identity;

namespace UtahProject.Api.Data.Models;

public class UserModel : IdentityUser
{
    public string DinoOwner { get; set; }
}