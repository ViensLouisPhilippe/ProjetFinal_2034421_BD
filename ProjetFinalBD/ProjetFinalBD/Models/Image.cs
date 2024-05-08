using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjetFinalBD.Models
{
    [Table("Image", Schema = "Players")]
    [Index("Identifiant", Name = "UC_Image_Identifiant", IsUnique = true)]
    public partial class Image
    {
        public Image()
        {
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("ImageID")]
        public int ImageId { get; set; }
        [StringLength(100)]
        public string Nom { get; set; } = null!;
        public Guid Identifiant { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        public byte[]? FichierImage { get; set; }

        [ForeignKey("PlayerId")]
        [InverseProperty("Images")]
        public virtual Player Player { get; set; } = null!;
        [InverseProperty("Image")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
