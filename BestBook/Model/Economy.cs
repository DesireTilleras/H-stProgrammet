using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hastprogrammet.CustomAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hastprogrammet.Model
{
    [Table("Economy")]
    public partial class Economy
    {
        public Economy()
        {
           
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Description { get; set; }

        [Column("HorseId")]
        [ValidateAuthorIdExistInDb()]
        public int? HorseId { get; set; }
 
        [ForeignKey(nameof(HorseId))]
        [InverseProperty("Horses")]
        public virtual Horse Horse { get; set; }

        
    }
}
