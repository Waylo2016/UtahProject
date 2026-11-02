namespace UtahProject.Api.DTO.User;

public class CreateUserDto
{
    /// <summary>
    /// Data required to create a new user
    /// </summary>
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}