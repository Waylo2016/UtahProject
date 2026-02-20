using System.ComponentModel.DataAnnotations;

namespace Utah_Project_API.Models;

public class Species
{

    public int SpeciesId { get; set; }
    
    public string SpeciesName { get; set; }
    
    public string SpeciesDescription { get; set; }
}