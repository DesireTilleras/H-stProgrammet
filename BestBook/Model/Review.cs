using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hastprogrammet.Model
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(64)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Text { get; set; }
        [Column("BookID")]
        public int? BookId { get; set; }
        public int? Stars { get; set; }
        
        [Column(TypeName = "smalldatetime")]
        public DateTime? PostedDate { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("Reviews")]
        public virtual Book Book { get; set; }
    }
}
