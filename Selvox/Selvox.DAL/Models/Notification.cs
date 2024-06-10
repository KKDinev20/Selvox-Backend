using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Selvox.DAL.Models;

public partial class Notification
{
    [Key]
    public int NotificationID { get; set; }

    public int? UserID { get; set; }

    public string? Message { get; set; }

    public bool? ReadStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SentAt { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Notifications")]
    public virtual User? User { get; set; }
}
