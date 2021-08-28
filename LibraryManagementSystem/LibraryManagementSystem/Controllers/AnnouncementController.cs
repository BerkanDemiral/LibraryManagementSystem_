using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        LIBRARYEntities1 db = new LIBRARYEntities1();

        public ActionResult Index()
        {
            var values = db.announcements.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnnouncement(announcements p)
        {
            p.date = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            db.announcements.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = db.announcements.Find(id);
            db.announcements.Remove(announcement); // remove kullanmak için parametre olarak o nesneyi girmemiz gerekmekte
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAnnouncement(int id)
        {
            var announcement = db.announcements.Find(id);
            return View(announcement);
        }

        public ActionResult UpdateAnnouncement(announcements p)
        {
            var announcement = db.announcements.Find(p.id);
            announcement.category = p.category;
            announcement.content = p.content;
            announcement.date = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}