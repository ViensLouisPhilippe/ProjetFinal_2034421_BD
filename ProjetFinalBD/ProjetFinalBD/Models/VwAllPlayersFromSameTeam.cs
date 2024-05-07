using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Keyless]
    public partial class VwAllPlayersFromSameTeam
    {
        [Column("Full name")]
        [StringLength(66)]
        public string FullName { get; set; } = null!;
        public int? Number { get; set; }
        public int AgeExperience { get; set; }
        [StringLength(30)]
        public string? ContractTerms { get; set; }
        [StringLength(20)]
        public string? Acquired { get; set; }
        public int? YearExpire { get; set; }
        [StringLength(30)]
        public string? TeamName { get; set; }
        [Column("Active?")]
        [StringLength(7)]
        [Unicode(false)]
        public string? Active { get; set; }
        [StringLength(40)]
        public string? ReasonUnavailability { get; set; }
        [StringLength(15)]
        public string? ExpectedDateReturn { get; set; }
    }
}
