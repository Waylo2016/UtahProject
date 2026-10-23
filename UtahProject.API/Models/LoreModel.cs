using System;
using System.Text.Json.Serialization;

namespace UtahProject.Api.Models;

public class LoreModel
{
    public Guid LoreId { get; set; }
    public Guid DinoId { get; set; }
    public int ServeOrder { get; set; }
    public string LoreText { get; set; }

    [JsonIgnore]
    public DinosaurModel Dinosaur { get; set; } = null!;
}