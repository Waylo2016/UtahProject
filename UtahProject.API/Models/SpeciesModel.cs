using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UtahProject.Api.Enums;

namespace UtahProject.Api.Models;

public class SpeciesModel
{
    public Guid SpeciesId { get; set; }

    public string SpeciesName { get; set; } = string.Empty;

    public Diet Diet { get; set; }

    public Diet LivingArea { get; set; }
    
    [JsonIgnore]
    public ICollection<DinosaurModel> Dinosaurs { get; } = new List<DinosaurModel>();
}