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
        public IActionResult AddHorse()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddHorse(Horse horse)
        {
            if (ModelState.IsValid)
            {
                Context.Horses.Add(horse);
                Context.SaveChanges();
                TempData["message"] = "Horse added to database";
                return RedirectToAction("Index", "Home");
            }
            return View(horse);

        }
        public IActionResult HorseSearch(string SearchText)
        {
            var horses = Context.Horses.Where(a => a.Name.Contains(SearchText));
            return View(horses);
        }
        public IActionResult SearchHorse(string name)
        {            
            var horses = Context.Horses.ToList();
            if (name != null)
            {
                horses = Context.Horses.Where(a => a.Name.Contains(name)).ToList();
            }
            
            return View(horses);
        }
        public IActionResult HorseDetails(int id)
        {
            var horse = Context.Horses.FirstOrDefault(b => b.Id == id);
            var economyPosts = Context.Economies.Where(b => b.HorseId == id).ToList();
            ViewData["economyList"] = economyPosts;

            return View(horse);

        }
        //public IActionResult EditAuthor(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var author = Context.Authors.Find(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(author);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        ////public IActionResult EditAuthor(Author newAuthor)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        var author = Context.Authors.Find(newAuthor.Id);
        ////        author.Name = newAuthor.Name;
        ////        author.HomeTown = newAuthor.HomeTown;
        ////        Context.Authors.Update(author);
        ////        Context.SaveChanges();
        ////        return RedirectToAction("AuthorDetails", "Author", new { id = author.Id });
        ////    }
        ////    return View(newAuthor);
        //}
        public IActionResult DeleteHorse(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var author = Context.Horses.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHorsePost(int? id)
        {
            var horse = Context.Horses.Find(id);
            if (horse == null)
            {
                return NotFound();
            }            
            Context.Horses.Remove(horse);
            Context.SaveChanges();
            TempData["message"] = "Horse removed from database";
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
