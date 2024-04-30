using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Contract", Schema = "Players")]
    [Index("PlayerId", Name = "UC_Contract_PlayerID", IsUnique = true)]
    public partial class Contract
    {
        [Key]
        [Column("ContractID")]
        public int ContractId { get; set; }
        [StringLength(30)]
        public string? ContractTerms { get; set; }
        [Column("AverageSalary/Year", TypeName = "money")]
        public decimal? AverageSalaryYear { get; set; }
        [Column(TypeName = "money")]
        public decimal? Guaranteed { get; set; }
        public int? YearExpire { get; set; }
        [StringLength(20)]
        public string? Acquired { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Contract")]
        public virtual Player Player { get; set; } = null!;
    }
}
