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
            return View(values);
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