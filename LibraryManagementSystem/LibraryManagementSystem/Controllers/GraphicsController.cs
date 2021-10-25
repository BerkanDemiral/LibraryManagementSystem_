using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class GraphicsController : Controller
    {
        // GET: Graphics
        LIBRARYEntities1 db = new LIBRARYEntities1();
        public ActionResult Graphs()
        {
            return View();
        }

        public ActionResult VisualizationAuthorResult()
        {
            return Json(listAuthors(), JsonRequestBehavior.AllowGet);
        }


        public List<PegeCountOfBooks> listAuthors()
        {
            var values = db.books.ToList();
            List<PegeCountOfBooks> authorsBooks = new List<PegeCountOfBooks>();
            foreach (var item in values)
            {
                authorsBooks.Add(new PegeCountOfBooks()
                {
                    bookName = item.name,
                    pageCount = Convert.ToInt32(item.number_of_page)
                });
            }
            return authorsBooks;
        }

        //public List<AuthorsBooks> listAuthors()
        //{
        //    List<AuthorsBooks> authorsBooks = new List<AuthorsBooks>();

        //    authorsBooks = db.books.Select(x => new AuthorsBooks
        //    {
        //        authorName = "dsfsdfsdf",
        //        numberOfBooks = 454
        //    }).ToList();

        //    return authorsBooks;
        //}


    }
}
