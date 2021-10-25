using LibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Reporting
        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookReport()
        {
            var values = db.books.ToList();
            return View(values);
        }

        public ActionResult AuthorReport()
        {
            var values = db.authors.ToList();
            return View(values);
        }

        public ActionResult CategoryReport()
        {
            var values = db.categories.ToList();
            return View(values);
        }
    }
}