namespace Utah_Project_API.DTO.Species;

/// <summary>
/// DTO for creating a new species.
/// </summary>
public class CreateSpeciesDTO
{
    public string speciesName { get; set; }
    
    public string speciesDescription { get; set; }
}