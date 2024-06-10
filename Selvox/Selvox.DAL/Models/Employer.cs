using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Index("ContactEmail", Name = "UQ__Employer__FFA796CD3327029E", IsUnique = true)]
public partial class Employer
{
    [Key]
    public int EmployerID { get; set; }

    [StringLength(255)]
    public string CompanyName { get; set; } = null!;

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? State { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(20)]
    public string? PostalCode { get; set; }

    [StringLength(100)]
    public string? ContactEmail { get; set; }

    [StringLength(20)]
    public string? ContactPhone { get; set; }

    [StringLength(200)]
    public string? Website { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Employer")]
    public virtual ICollection<EmployerJob> EmployerJobs { get; } = new List<EmployerJob>();

    [InverseProperty("Employer")]
    public virtual ICollection<Interview> Interviews { get; } = new List<Interview>();
}
