using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace UtahProject.Api.Models;

public class UserModel : IdentityUser<Guid>
{
    [JsonIgnore]
    public required ICollection<DinosaurModel> Dinosaurs { get; set; }
}