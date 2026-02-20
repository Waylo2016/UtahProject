using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DinoModel = Utah_Project_API.Models.Dinosaur.Dinosaur;

namespace Utah_Project_API.Models;

public class Nesting_Lib
{
    public int NestingId { get; set; }
    
    public string NestingDescription { get; set; }
    
    [Column(TypeName = "nvarchar(max)")]
    public string ExtendedDesciption { get; set; }

    public int? Parent1Code { get; set; }
    
    public DinoModel?  Parent1 { get; set; }

    public int? Parent2Code { get; set; }
    
    public DinoModel? Parent2 { get; set; }

    public ICollection<DinoModel> Offsprings { get; set; } = new List<DinoModel>();
}