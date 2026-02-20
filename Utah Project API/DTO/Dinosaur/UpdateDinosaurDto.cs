using Utah_Project_API.Enums;

namespace Utah_Project_API.DTO.Dinosaur;

public class UpdateDinosaurDto
{
    public string? DinoName { get; set; }
    public string? Color { get; set; }
    public int SpeciesId { get; set; }
    public string? Picture { get; set; }
    public Gender? gender { get; set; }  
}