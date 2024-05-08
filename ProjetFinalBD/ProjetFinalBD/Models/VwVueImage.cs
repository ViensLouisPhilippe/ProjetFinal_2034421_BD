using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Keyless]
    public partial class VwVueImage
    {
        [Column("Full name")]
        [StringLength(66)]
        public string FullName { get; set; } = null!;
        public int? Number { get; set; }
        public int AgeExperience { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [StringLength(30)]
        public string? ContractTerms { get; set; }
        [StringLength(30)]
        public string? TeamName { get; set; }
        [StringLength(100)]
        public string? Nom { get; set; }
        public Guid? Identifiant { get; set; }
    }
}
