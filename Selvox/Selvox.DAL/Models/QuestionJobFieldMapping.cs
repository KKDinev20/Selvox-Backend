using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class QuestionJobFieldMapping
{
    [Key]
    public int MappingId { get; set; }

    public int? QuestionId { get; set; }

    public int JobFieldId { get; set; }

    [ForeignKey("JobFieldId")]
    [InverseProperty("QuestionJobFieldMappings")]
    public virtual JobRole? JobField { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("QuestionJobFieldMappings")]
    public virtual PersonalityQuestion? Question { get; set; }
}
