using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

[Index("UserId", Name = "UQ__Roles__1788CC4D067AC588", IsUnique = true)]
public partial class Role
{
    [Key]
    public int RoleId { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Role")]
    public virtual User User { get; set; } = null!;
}
