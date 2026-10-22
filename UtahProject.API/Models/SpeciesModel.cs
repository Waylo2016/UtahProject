

using System;

namespace UtahProject.Api.Models;

public class SpeciesModel
{
    public Guid SpeciesId { get; set; }

    public string SpeciesName { get; set; } = string.Empty;
    
    public string Diet { get; set; } = string.Empty;

    public string LivingArea { get; set; } = string.Empty;
}