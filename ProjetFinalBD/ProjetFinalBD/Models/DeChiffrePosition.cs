using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Keyless]
    [Table("DeChiffrePosition", Schema = "Players")]
    public partial class DeChiffrePosition
    {
        [StringLength(50)]
        public string? Position { get; set; }
    }
}
