using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Application
{
    [Key]
    public int ApplicationId { get; set; }

    public int? JobListingId { get; set; }

    public int? UserId { get; set; }

    public DateTimeOffset ApplicationDate { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    public string? Resume { get; set; }

    public string? CoverLetter { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    [ForeignKey("JobListingId")]
    [InverseProperty("Applications")]
    public virtual JobListing? JobListing { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Applications")]
    public virtual User? User { get; set; }
}
