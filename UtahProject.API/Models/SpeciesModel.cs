

using System;
using UtahProject.Api.Enums;

namespace UtahProject.Api.Models;

public class SpeciesModel
{
    public Guid SpeciesId { get; set; }

    public string SpeciesName { get; set; } = string.Empty;

    public Diet Diet { get; set; }

    public Diet LivingArea { get; set; }
}