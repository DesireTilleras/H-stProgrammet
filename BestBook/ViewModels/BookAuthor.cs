using Hastprogrammet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hastprogrammet.ViewModels
{
    public class BookAuthor
    {
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Book> Books { get; set; } = new List<Book>();

    }
}
