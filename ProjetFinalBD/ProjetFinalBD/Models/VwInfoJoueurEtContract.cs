using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Keyless]
    public partial class VwInfoJoueurEtContract
    {
        [Column("Nom complet")]
        [StringLength(66)]
        public string NomComplet { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public int? Number { get; set; }
        [StringLength(30)]
        public string? ContractTerms { get; set; }
        [Column("AverageSalary/Year", TypeName = "money")]
        public decimal? AverageSalaryYear { get; set; }
        [Column(TypeName = "money")]
        public decimal? Guaranteed { get; set; }
        public int? YearExpire { get; set; }
        [StringLength(20)]
        public string? Acquired { get; set; }
        [Column("Active?")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Active { get; set; }
        [StringLength(40)]
        public string? ReasonUnavailability { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateSinceUnavailability { get; set; }
        [StringLength(15)]
        public string? ExpectedDateReturn { get; set; }
    }
}
