using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UtahProject.Api.Models;

public class DinosaurModel
{
    public Guid DinoId { get; set; }
    public string DinoName { get; set; }
    public Guid SpeciesId { get; set; }
    public Guid OwnedBy { get; set; }

    [JsonIgnore]
    public SpeciesModel Species { get; set; } = null!;

    [JsonIgnore] 
    public ICollection<LoreModel> Lore { get; } = new List<LoreModel>();

    [JsonIgnore]
    public UserModel Owner { get; set; } = null!;
}