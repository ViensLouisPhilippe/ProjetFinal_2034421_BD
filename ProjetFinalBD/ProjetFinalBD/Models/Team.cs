using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Team", Schema = "Teams")]
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("TeamID")]
        public int TeamId { get; set; }
        [StringLength(30)]
        public string TeamName { get; set; } = null!;
        [StringLength(30)]
        public string? CoachName { get; set; }
        public int SeasonYear { get; set; }
        [Column("Record(W/L/T)")]
        [StringLength(10)]
        public string RecordWLT { get; set; } = null!;
        [Column("PlayOffRecord(W/L)")]
        [StringLength(6)]
        public string? PlayOffRecordWL { get; set; }

        [InverseProperty("Team")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
