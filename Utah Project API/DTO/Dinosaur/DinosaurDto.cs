using Utah_Project_API.Enums;

namespace Utah_Project_API.DTO.Dinosaur;

public class DinosaurDto
{
    public required string DinoName { get; set; }
    public required string Color { get; set; }
    public required int SpeciesId { get; set; }
    public required string Picture { get; set; }
    public required Gender gender { get; set; }
}