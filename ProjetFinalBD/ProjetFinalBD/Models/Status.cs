using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Status", Schema = "Players")]
    public partial class Status
    {
        [Key]
        [Column("StatusID")]
        public int StatusId { get; set; }
        [StringLength(40)]
        public string? ReasonUnavailability { get; set; }
        [StringLength(15)]
        public string? ExpectedDateReturn { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateSinceUnavailability { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Statuses")]
        public virtual Player Player { get; set; } = null!;
    }
}
