using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Defense", Schema = "Stats")]
    public partial class Defense
    {
        [Key]
        [Column("DefenseID")]
        public int DefenseId { get; set; }
        [Column("StatID")]
        public int StatId { get; set; }
        public int? SoloTackles { get; set; }
        public int? AssistedTackle { get; set; }
        [Column(TypeName = "decimal(10, 1)")]
        public decimal? Sack { get; set; }
        public int? Interception { get; set; }
        public int? ForceFumble { get; set; }

        [ForeignKey("StatId")]
        [InverseProperty("Defenses")]
        public virtual Stat Stat { get; set; } = null!;
    }
}
