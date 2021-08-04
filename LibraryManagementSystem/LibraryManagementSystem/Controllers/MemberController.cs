using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index(int page=1)
        {
            var values = db.members.ToList().ToPagedList(page,5);
            return View(values);
        }

        [HttpGet] // hiçbir işlem yapılmadıysa bu çalışsın
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(members member)
        {

            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }

            db.members.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMember(int id)
        {
            var member = db.members.Find(id);
            db.members.Remove(member); // remove kullanmak için parametre olarak o nesneyi girmemiz gerekmekte
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetMember(int id)
        {
            var member = db.members.Find(id);
            return View("GetMember", member);
        }

        public ActionResult UpdateMember(members member)
        {
            var memb = db.members.Find(member.id);
            memb.first_name = member.first_name;
            memb.last_name = member.last_name;
            memb.email = member.email;
            memb.user_name = member.user_name;
            memb.phone_number = member.phone_number;
            memb.photos = member.photos;
            memb.school = member.school;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}