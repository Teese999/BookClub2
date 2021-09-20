using BookClub2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookClub2.DataContext;

namespace BookClub2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TryLogin(string Name)
        {
          
            using (var db = new ApplicationDbContext())
            {
                if (db.Users.FirstOrDefault(x => x.Name == Name) == null)
                {
                    db.Users.Add(new User(Name));
                    db.SaveChanges();
                    
                }
                return View("UserAccount", db.Users.First(x => x.Name == Name));
            }
            
        }
        [HttpPost]
        public IActionResult AddBook(Guid BookId, Guid Userid)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.BookReads.Where(x => x.BookId == BookId && x.UserId == Userid).ToList().Count == 0)
                {
                    db.BookReads.Add(new BooksRead(Userid, BookId));
                    db.SaveChanges();
                   
                }
                return View("UserAccount", db.Users.First(x => x.Id == Userid));
            }
            
        }
        [HttpPost]
        public IActionResult DeleteBook(Guid BookId, Guid Userid)
        {
            using (var db = new ApplicationDbContext())
            {
                var itemToDel = db.BookReads.Where(x => x.UserId == Userid).ToList().Where(x => x.BookId == BookId).First();
                db.BookReads.Remove(itemToDel);
                db.SaveChanges();
                return View("UserAccount", db.Users.First(x => x.Id == Userid));
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
