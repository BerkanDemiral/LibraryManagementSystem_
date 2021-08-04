using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index()
        {
            var values = db.personnels.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddPersonnel() // deger ekleme yapılmıyorsa bu metod çalışsın
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPersonnel(personnels prs)
        {

            if (!ModelState.IsValid)
            {
                return View("AddPersonnel");
            }

            db.personnels.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeletePersonnel(int id)
        {
            var personnel = db.personnels.Find(id);
            db.personnels.Remove(personnel); // remove kullanmak için parametre olarak o nesneyi girmemiz gerekmekte
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetPersonnel(int id)
        {
            var personnel = db.personnels.Find(id);
            return View("GetPersonnel", personnel);
        }

        public ActionResult UpdatePersonnel(personnels pers)
        {
            var prs = db.personnels.Find(pers.id);
            prs.personnel = pers.personnel;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}