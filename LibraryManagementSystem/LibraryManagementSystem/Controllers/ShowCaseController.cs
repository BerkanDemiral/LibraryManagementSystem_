using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using LibraryManagementSystem.Models.Classes;
namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        LIBRARYEntities1 db = new LIBRARYEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 enumerableClass = new Class1();
            enumerableClass.Vaue1 = db.books.Where(x=>x.book_status==true && x.situation==true).ToList().Take(9);
            enumerableClass.Value2 = db.about_us.ToList();

            return View(enumerableClass);
        }

        [HttpPost]
        public ActionResult Index(contact cnt)
        {
            db.contact.Add(cnt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
   
        public ActionResult GetBook(int id)
        {
            var book = db.books.Find(id);
            return View(book);
        }

        public ActionResult BookDetail(int? id)
        {
            return PartialView(db.books.FirstOrDefault(x => x.id == id));
        }
    }
}