using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Index()
        {
            var values = db.books.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            // normalde sadece sayfa görüntülenince bir işlem yapmıyorduk ama burada listeleme işlemi yapılacağı için;
            List<SelectListItem> categoryValue = (from category in db.categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = category.name,
                                               Value = category.id.ToString()
                                           }).ToList();
            ViewBag.value1 = categoryValue;

            List<SelectListItem> authorValue = (from author in db.authors.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = author.first_name + " " + author.last_name,
                                                    Value = author.id.ToString()
                                                }).ToList();

            ViewBag.value2 = authorValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(books book)
        {
            var category = db.categories.Where(ctg => ctg.id == book.categories.id).FirstOrDefault(); // ilk ya da varsayılan değerini aldık
            var author = db.authors.Where(auth => auth.id == book.authors.id).FirstOrDefault();

            book.categories = category;
            book.authors = author;

            db.books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.books.Find(id); // id değerine göre o kategoriyi bul
            db.books.Remove(book); // bulduğu kategoriyi sil
            db.SaveChanges();
            return RedirectToAction("Index"); // kategorilerin listelendiği aksiyona yönlendirmesini söyledik. 

        }

        public ActionResult GetBook(int id)
        {
            var book = db.books.Find(id);

            List<SelectListItem> categoryValue = (from category in db.categories.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.name,
                                                      Value = category.id.ToString()
                                                  }).ToList();
            ViewBag.value1 = categoryValue;

            List<SelectListItem> authorValue = (from author in db.authors.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = author.first_name + " " + author.last_name,
                                                    Value = author.id.ToString()
                                                }).ToList();

            ViewBag.value2 = authorValue;

            return View("GetBook", book);
        }


        public ActionResult UpdateBook(books book)
        {
            var _book = db.books.Find(book.id);
            _book.name = book.name;
            _book.publication_year = book.publication_year;
            _book.publisher = book.publisher;
            _book.number_of_page = book.number_of_page;
            _book.situation = true;

            var category = db.categories.Where(ctg => ctg.id == book.categories.id).FirstOrDefault();
            var author = db.authors.Where(auth => auth.id == book.authors.id).FirstOrDefault();

            _book.categories = category;
            _book.authors = author;

            db.SaveChanges();
            return RedirectToAction("Index");

            
        }


    }
}