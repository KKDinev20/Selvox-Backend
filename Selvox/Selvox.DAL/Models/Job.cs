using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Job
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    public int? EmployerID { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [ForeignKey("EmployerID")]
    [InverseProperty("Jobs")]
    public virtual User? Employer { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
