using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using LibraryManagementSystem.Models.Classes;
namespace LibraryManagementSystem.Controllers
{
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        DBLIBRARYEntities db = new DBLIBRARYEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 enumerableClass = new Class1();
            enumerableClass.Vaue1 = db.books.ToList();
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
    }
}