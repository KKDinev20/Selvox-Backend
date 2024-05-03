using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Application
{
    [Key]
    public int Id { get; set; }

    public int? JobID { get; set; }

    public int? UserID { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [ForeignKey("JobID")]
    [InverseProperty("Applications")]
    public virtual Job? Job { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Applications")]
    public virtual User? User { get; set; }
}
