using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Player", Schema = "Players")]
    [Index("Number", Name = "UC_Player_Number", IsUnique = true)]
    public partial class Player
    {
        public Player()
        {
            Stats = new HashSet<Stat>();
            Statuses = new HashSet<Status>();
        }

        [Key]
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [StringLength(25)]
        public string LastName { get; set; } = null!;
        [StringLength(40)]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public int AgeExperience { get; set; }
        public int? Number { get; set; }
        [StringLength(25)]
        public string? Position { get; set; }
        public bool Available { get; set; }
        [Column("TeamID")]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        [InverseProperty("Players")]
        public virtual Team Team { get; set; } = null!;
        [InverseProperty("Player")]
        public virtual Contract? Contract { get; set; }
        [InverseProperty("Player")]
        public virtual ICollection<Stat> Stats { get; set; }
        [InverseProperty("Player")]
        public virtual ICollection<Status> Statuses { get; set; }
    }
}
