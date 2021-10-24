using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class MessagesController : Controller
    {
        LIBRARYEntities1 db = new LIBRARYEntities1();
        //public ActionResult Index()
        //{
        //    var userEmail = (string)Session["email"].ToString();
        //    var m = db.messages.Where(x => x.to_ == userEmail.ToString()).ToList(); ;
        //    return View(m);
        //}

        public ActionResult Inbox()
        {
            var userEmail = (string)Session["email"];
            var m = db.messages.Where(x => x.to_ == userEmail).ToList();
            return View(m);
        }

        public ActionResult Outbox()
        {
            var userEmail = (string)Session["email"];
            var m = db.messages.Where(x => x.sender == userEmail).ToList(); ;
            return View(m);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(messages message)
        {
            var userEmail = (string)Session["email"];
            message.sender = userEmail.ToString();
            message.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.messages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Outbox","Messages");
        }

        public PartialViewResult MessagePartial_()
        {
            string userEmail = (string)Session["email"]; // kullancının emailini aldık.
            var numberOfInbox = db.messages.Where(x => x.to_ == userEmail).Count();
            ViewBag.inbox = numberOfInbox;

            var numberOfSendBox = db.messages.Where(x => x.sender == userEmail).Count();
            ViewBag.sendBox = numberOfSendBox;

            return PartialView();
        }
    }
}