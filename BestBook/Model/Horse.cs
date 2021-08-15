using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hastprogrammet.Model
{
    [Table("Horse")]
    public partial class Horse
    {
        public Horse()
        {
            //Economies = new HashSet<Economy>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [StringLength(64)]
        public string Height { get; set; }
        [StringLength(64)]
        public string BirthYear { get; set; }
        [StringLength(64)]

        [InverseProperty(nameof(Economy.Horse))]
        public virtual ICollection<Economy> Economies { get; set; }
    }
}
