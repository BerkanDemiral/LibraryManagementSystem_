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
        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.events.Where(evnt => evnt.process_situation == true).ToList();
            return View(values);
        }
    }
}