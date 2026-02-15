using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utah_Project_API.Models;

public class Nesting_Lib
{
    public int NestingId { get; set; }
    
    public string NestingDescription { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string ExtendedDesciption { get; set; }

    public int? Parent1Id { get; set; }
    
    public Dinosaur.Dinosaur? Parent1 { get; set; }

    public int? Parent2Id { get; set; }
    
    public Dinosaur.Dinosaur? Parent2 { get; set; }

    public ICollection<Dinosaur.Dinosaur> Offsprings { get; set; } = new List<Dinosaur.Dinosaur>();
}