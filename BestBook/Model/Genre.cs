using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hastprogrammet.Model
{
    [Table("Genre")]
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(32)]
        public string GenreName { get; set; }

        [InverseProperty(nameof(Book.Genre))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
