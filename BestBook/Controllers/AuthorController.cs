using Hastprogrammet.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hastprogrammet.Controllers
{
    public class HorseController : Controller
    {
        public HorseContext Context { get; set; }
        public HorseController(HorseContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                Context.Authors.Add(author);
                Context.SaveChanges();
                TempData["message"] = "Author added to database";
                return RedirectToAction("Index", "Home");
            }
            return View(author);

        }
        public IActionResult AuthorSearch(string SearchText)
        {
            var authors = Context.Authors.Where(a => a.Name.Contains(SearchText));
            return View(authors);
        }
        public IActionResult SearchAuthor(string name)
        {            
            var authors = Context.Authors.ToList();
            if (name != null)
            {
                authors = Context.Authors.Where(a => a.Name.Contains(name)).ToList();
            }
            
            return View(authors);
        }
        public IActionResult AuthorDetails(int id)
        {
            var author = Context.Authors.FirstOrDefault(b => b.Id == id);
            var books = Context.Books.Where(b => b.AuthorId == id).ToList();
            ViewData["bookList"] = books;

            return View(author);

        }
        public IActionResult EditAuthor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var author = Context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAuthor(Author newAuthor)
        {
            if (ModelState.IsValid)
            {
                var author = Context.Authors.Find(newAuthor.Id);
                author.Name = newAuthor.Name;
                author.HomeTown = newAuthor.HomeTown;
                Context.Authors.Update(author);
                Context.SaveChanges();
                return RedirectToAction("AuthorDetails", "Author", new { id = author.Id });
            }
            return View(newAuthor);
        }
        public IActionResult DeleteAuthor(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var author = Context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuthorPost(int? id)
        {
            var author = Context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }            
            Context.Authors.Remove(author);
            Context.SaveChanges();
            TempData["message"] = "Author removed from database";
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Author author)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Context.Authors.Add(author);
        //        Context.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(author);
        //}
    }
}
