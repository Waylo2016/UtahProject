using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Utah_Project_API.Models;

public class User : IdentityUser
{
    public string? DisplayName { get; set; }
    
    public DateTime? LastLogin { get; set; }
    
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
    
    public ICollection<Dinosaur.Dinosaur> OwnedDinosaurs { get; set; } = new List<Dinosaur.Dinosaur>();
}