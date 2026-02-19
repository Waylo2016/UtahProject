namespace Utah_Project_API.DTO.Dinosaur;

public class UpdateDinosaurDto
{
    public required string DinoName { get; set; }
    public required string Color { get; set; }
    public required int SpeciesId { get; set; }
    public required string? Picture { get; set; }
}