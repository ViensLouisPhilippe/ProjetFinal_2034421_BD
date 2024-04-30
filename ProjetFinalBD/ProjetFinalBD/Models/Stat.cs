using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Stat", Schema = "Stats")]
    public partial class Stat
    {
        public Stat()
        {
            Defenses = new HashSet<Defense>();
            Passings = new HashSet<Passing>();
            Receivings = new HashSet<Receiving>();
            Rushings = new HashSet<Rushing>();
        }

        [Key]
        [Column("StatID")]
        public int StatId { get; set; }
        public int? GamePlayed { get; set; }
        public int? GameMissed { get; set; }
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Stats")]
        public virtual Player Player { get; set; } = null!;
        [InverseProperty("Stat")]
        public virtual ICollection<Defense> Defenses { get; set; }
        [InverseProperty("Stat")]
        public virtual ICollection<Passing> Passings { get; set; }
        [InverseProperty("Stat")]
        public virtual ICollection<Receiving> Receivings { get; set; }
        [InverseProperty("Stat")]
        public virtual ICollection<Rushing> Rushings { get; set; }
    }
}
