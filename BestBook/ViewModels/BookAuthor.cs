using Hastprogrammet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hastprogrammet.ViewModels
{
    public class BookAuthor
    {
        public List<Horse> Horses { get; set; } = new List<Horse>();
        public List<Economy> Economies { get; set; } = new List<Economy>();

    }
}
