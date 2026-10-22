using System;

namespace UtahProject.Api.Models;

public class DinosaurModel
{
    public Guid DinoId { get; set; }
    public string DinoName { get; set; }
    public Guid SpeciesId { get; set; }
    public Guid OwnedBy { get; set; }
}