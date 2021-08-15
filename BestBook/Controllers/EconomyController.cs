using Hastprogrammet.Model;
using Hastprogrammet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;

namespace Hastprogrammet.Controllers
{
    public class EconomyController : Controller
    {
        public HorseContext Context { get; set; }

        public EconomyController(HorseContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Economy economy)
        {           
            
            if (ModelState.IsValid)
            {                
                Context.Economies.Add(economy);
                Context.SaveChanges();
                TempData["message"] = "Book added to database";
                return RedirectToAction("Index","Home");
            }

            return View(economy);
        }        

        public IActionResult SearchEconomy(string SearchText)
        {
            var posts = Context.Economies.Where(b => b.Description.Contains(SearchText));
            return View(posts);
        }
        public IActionResult EconomyDetails(int id)
        {
            var economyHorseID = Context.Economies.Where(b => b.Id == id).Select(b => b.HorseId).First();
            var horse = Context.Horses.First(a => a.Id == economyHorseID);
            ViewData["horse"] = horse.Name;
            var post = Context.Economies.FirstOrDefault(b => b.Id == id);

            return View(post);
        }
        //public IActionResult DeleteBook(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var book = Context.Books.Find(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(book);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var economy = Context.Economies.Find(id);
            if (economy == null)
            {
                return NotFound();
            }
           
            Context.Economies.Remove(economy);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditEconomy(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var economy = Context.Economies.Find(Id);
            if (economy == null)
            {
                return NotFound();
            }
            return View(economy);
        }
        //POST - EDIT
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditBook(Book newBook)
        //{            
        //    if (ModelState.IsValid)
        //    {
        //        var book = Context.Books.Find(newBook.Id);
        //        book.Name = newBook.Name;
        //        book.Description = newBook.Description;                
        //        Context.Books.Update(book);
        //        Context.SaveChanges();
        //        return RedirectToAction("BookDetails", "Book", new { id = book.Id});
        //    }
        //    return View(newBook);
        //}
        //public IActionResult ListTop10Books()
        //{
        //    var countBooks = Context.Books.Count();

        //    int amount = 10;

        //    if (countBooks <10)
        //    {
        //        amount = countBooks;
        //    }
        //    var books = Context.Books.OrderByDescending(b => b.AvgStar).Take(amount).ToList();

        //    foreach (var book in books)
        //    {
        //        if (book.AvgStar == null)
        //        {
        //            book.AvgStar = 0;
        //        }
        //    }

        //    return View(books);
        //}

    }
}