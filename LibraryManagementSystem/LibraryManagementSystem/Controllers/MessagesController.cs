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

        [HttpGet]
        public ActionResult Inbox()
        {
            string userEmail = (string)Session["email"];
            var message = db.messages.Where(x => x.to_ == userEmail.ToString()).ToList();

            return View(message);
        }
        [HttpPost]
        public ActionResult Inbox(string word)
        {
            string userEmail = (string)Session["email"];
            var message = db.messages.Where(x => x.to_ == userEmail.ToString() && x.message.Contains(word)).ToList();
            
            return View(message);
        }

        [HttpGet]
        public ActionResult Outbox()
        {
            string userEmail = (string)Session["email"];
            var message = db.messages.Where(x => x.sender == userEmail.ToString()).ToList();

            return View(message);
        }

        [HttpPost]
        public ActionResult Outbox(string word)
        {
            string userEmail = (string)Session["email"];
            var message = db.messages.Where(x => x.sender == userEmail.ToString() && x.message.Contains(word)).ToList();

            return View(message);
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            var userEmail = (string)Session["email"];
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(messages msg)
        {
            var userEmail = (string)Session["email"];
            msg.sender = userEmail.ToString();
            msg.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.messages.Add(msg);
            db.SaveChanges();
            return RedirectToAction("Outbox","Messages");
        }

        public ActionResult GetMessageDetail(int id)
        {
            var messageValue = db.messages.Find(id);
            return View(messageValue);
        }

    }
}