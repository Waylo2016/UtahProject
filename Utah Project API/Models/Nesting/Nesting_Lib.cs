using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utah_Project_API.Models;

public class Nesting_Lib
{
    public int nestingId { get; set; }
    
    public string nestingDescription { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string extendedDesciption { get; set; }

    public int? parent1Id { get; set; }
    public Dinosaur.Dinosaur? parent1 { get; set; }

    public int? parent2Id { get; set; }
    public Dinosaur.Dinosaur? parent2 { get; set; }

    public ICollection<Dinosaur.Dinosaur> offsprings { get; set; } = new List<Dinosaur.Dinosaur>();
}