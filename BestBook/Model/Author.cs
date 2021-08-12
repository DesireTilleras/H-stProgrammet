using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Hastprogrammet.Model
{
    [Table("Author")]
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }
        [StringLength(64)]
        public string HomeTown { get; set; }

        [InverseProperty(nameof(Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
