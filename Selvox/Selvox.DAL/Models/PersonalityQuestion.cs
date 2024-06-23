using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class PersonalityQuestion
{
    [Key]
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<QuestionJobFieldMapping> QuestionJobFieldMappings { get; } = new List<QuestionJobFieldMapping>();
}
