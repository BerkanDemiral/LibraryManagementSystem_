using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class MemberPanelController : Controller
    {
        // GET: MemberPanel

        LIBRARYEntities1 db = new LIBRARYEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            var userEmail = (string)Session["email"];
            var values = db.members.FirstOrDefault(z => z.email == userEmail);

            //

            var name = db.members.Where(x => x.email == userEmail).Select(y => y.first_name + " " + y.last_name).FirstOrDefault();
            ViewBag.name = name;

            var photo = db.members.Where(x => x.email == userEmail).Select(y => y.photos).FirstOrDefault();
            ViewBag.photo = photo;

            var userName = db.members.Where(x => x.email == userEmail).Select(y => y.user_name).FirstOrDefault();
            ViewBag.userName = userName;

            var school = db.members.Where(x => x.email == userEmail).Select(y => y.school).FirstOrDefault();
            ViewBag.school = school;

            var phone = db.members.Where(x => x.email == userEmail).Select(y => y.phone_number).FirstOrDefault();
            ViewBag.phone = phone;

            var memberId = db.members.Where(x => x.email == userEmail).Select(y => y.id).FirstOrDefault();
            var numberOfEvent = db.events.Where(x => x.member_id == memberId).Count();
            ViewBag.numberOfEvent = numberOfEvent;

            return View(values);
        }

        public PartialViewResult Announcement2()
        {
            var values = db.announcements.ToList();
            return PartialView("Announcement2", values);
        }

        public PartialViewResult Settings()
        {
            var userEmail = (string)Session["email"];
            var id = db.members.Where(x => x.email == userEmail).Select(y => y.id).FirstOrDefault();
            var getMember = db.members.Find(id);
            return PartialView("Settings",getMember);
        } 

        [HttpPost]
        public ActionResult Index2(members p)
        {
            var userEmail = (string)Session["email"];
            var member = db.members.FirstOrDefault(x => x.email == userEmail);
            member.password = p.password;
            member.first_name = p.first_name;
            member.photos = p.photos;
            member.school = p.school;
            member.user_name = p.user_name;
            db.SaveChanges();
            return RedirectToAction("Index","MemberPanel/Index/");
        }
        public ActionResult MyBooks()
        {
            var userEmail = (string)Session["email"];
            var id = db.members.Where(x => x.email == userEmail.ToString()).Select(z => z.id).FirstOrDefault();
            var values = db.events.Where(x => x.member_id == id).ToList();
            return View(values);
        }
        public ActionResult Announcement()
        {
            var announcementsList = db.announcements.ToList();
            return View(announcementsList);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication/Login");
        }
    }
}