using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Receiving", Schema = "Stats")]
    public partial class Receiving
    {
        [Key]
        [Column("ReceivingID")]
        public int ReceivingId { get; set; }
        [Column("StatID")]
        public int StatId { get; set; }
        public int? Receptions { get; set; }
        public int? YardsTotal { get; set; }
        [Column("TotalTD")]
        public int? TotalTd { get; set; }

        [ForeignKey("StatId")]
        [InverseProperty("Receivings")]
        public virtual Stat Stat { get; set; } = null!;
    }
}
