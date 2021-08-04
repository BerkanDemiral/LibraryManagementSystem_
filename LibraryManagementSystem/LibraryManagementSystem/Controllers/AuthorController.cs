using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity; // entity katmanına erişip db kodları kullanmmak için.. ( buisness-dataAccess gibi düşün)

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author

        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.authors.ToList();
            return View(values);
        }

        [HttpGet] // hiçbir işlem yapılmadıysa bu çalışsın
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(authors author)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }

            db.authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAuthor(int id)
        {
            var author = db.authors.Find(id);
            db.authors.Remove(author); // remove kullanmak için parametre olarak o nesneyi girmemiz gerekmekte
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAuthor(int id)
        {
            var author = db.authors.Find(id);
            return View("GetAuthor", author);
        }

        public ActionResult UpdateAuthor(authors author)
        {
            var auth = db.authors.Find(author.id);
            auth.first_name = author.first_name;
            auth.last_name = author.last_name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}