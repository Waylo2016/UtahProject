using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UtahProject.Api.Data.Models;

namespace UtahProject.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :IdentityDbContext<UserModel>(options)
{
    
}