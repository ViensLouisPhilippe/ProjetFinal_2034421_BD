using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Rushing", Schema = "Stats")]
    public partial class Rushing
    {
        [Key]
        [Column("RushingID")]
        public int RushingId { get; set; }
        [Column("StatID")]
        public int StatId { get; set; }
        public int? RushingAttempts { get; set; }
        public int? YardsTotal { get; set; }
        [Column("TotalTD")]
        public int? TotalTd { get; set; }

        [ForeignKey("StatId")]
        [InverseProperty("Rushings")]
        public virtual Stat Stat { get; set; } = null!;
    }
}
