using Hastprogrammet.Model;
using Hastprogrammet.Models;
using Hastprogrammet.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hastprogrammet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HorseContext _context;
        private static BookAuthor _bookAuthor;
        public HomeController(ILogger<HomeController> logger, HorseContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult about()
        {            
            return View();
        }
        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            IEnumerable<Horse> horses = _context.Horses;
            return View(horses);
        }
        public IActionResult BooksIframe()
        {
            var books = _bookAuthor.Economies;
            
            return View(books);
        }
        public IActionResult AuthorIframe()
        {
            var authors = _bookAuthor.Horses;
            return View(authors);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
