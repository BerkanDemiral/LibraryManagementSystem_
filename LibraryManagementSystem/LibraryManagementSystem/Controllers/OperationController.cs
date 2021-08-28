using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Index()
        {
            var values = db.events.Where(evnt => evnt.process_situation == true).ToList();
            return View(values);
        }
    }
}