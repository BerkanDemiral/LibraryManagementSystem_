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

        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Index()
        {
            var values = db.authors.Where(x => x.author_status == true).ToList();
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

            author.author_status = true;
            db.authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAuthor(int id)
        {
            var author = db.authors.Find(id);
            author.author_status = false; // remove kullanmak için parametre olarak o nesneyi girmemiz gerekmekte
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

        public ActionResult AuthorDetail(int id)
        {
            var books = db.books.Where(x => x.author_id == id).ToList();
            var nameAuthor = db.authors.Where(y => y.id == id).Select(z => z.first_name + " " + z.last_name).FirstOrDefault();
            ViewBag.name = nameAuthor;
            return View(books);
        }
    }
}