using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Passing", Schema = "Stats")]
    public partial class Passing
    {
        [Key]
        [Column("PassingID")]
        public int PassingId { get; set; }
        [Column("StatID")]
        public int StatId { get; set; }
        public int? YardsTotal { get; set; }
        [Column("TotalTD")]
        public int? TotalTd { get; set; }
        public int? Interception { get; set; }

        [ForeignKey("StatId")]
        [InverseProperty("Passings")]
        public virtual Stat Stat { get; set; } = null!;
    }
}
