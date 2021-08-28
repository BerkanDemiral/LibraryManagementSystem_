using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity; // entity katmanına erişip db kodları kullanmmak için.. ( buisness-dataAccess gibi düşün)

namespace LibraryManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Index()
        {
            var values = db.categories.ToList(); // values ksımında tüm değerleri topluyoruz. 

            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory() // deger ekleme yapılmıyorsa bu metod çalışsın
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(categories ctg)
        {
            db.categories.Add(ctg); // kategori tablosuna ekleme yap (parametre olarak gelen kategoriyi)
            db.SaveChanges(); // değişiklikleri kaydet
            return RedirectToAction("Index");  // AddCategory'e bağlanan view ekranını bize tekrar döndür.
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = db.categories.Find(id); // id değerine göre o kategoriyi bul
            db.categories.Remove(category); // bulduğu kategoriyi sil
            db.SaveChanges();
            return RedirectToAction("Index"); // kategorilerin listelendiği aksiyona yönlendirmesini söyledik. 

        }

        public ActionResult GetCategory(int id)
        {
            var category = db.categories.Find(id);
            return View("GetCategory", category); // bulduğu id değerine göre o kategori değerlerini getirmesini söyledik.
        }

        public ActionResult UpdateCategory(categories category) // bir kategori nesnesi güncelleneceği için direkt nesneyi parametre
                                                                           // olarak alıyoruz
        {
            var ctg = db.categories.Find(category.id);
            ctg.name = category.name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}