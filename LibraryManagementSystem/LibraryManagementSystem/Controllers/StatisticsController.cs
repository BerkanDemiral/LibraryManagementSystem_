﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
namespace LibraryManagementSystem.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistic
        LIBRARYEntities1 db = new LIBRARYEntities1();
        
        public ActionResult Index()
        {


            var value1 = db.members.Count();
            ViewBag.val1 = value1; // viewbag sayesinde bu actionResultun view  kısmında direkt @viewBag.val1 diyerek kullanabiliyoruz.

            var value2 = db.books.Count();
            ViewBag.val2 = value2;

            var value3 = db.books.Where(b => b.situation == false).Count(); // emanet olan kitapların sayısını almak
            ViewBag.val3 = value3;

            var value4 = db.penalties.Sum(p => p.price); // kasadaki toplam para tutarı
            ViewBag.val4 = value4;

            var value5 = db.categories.Where(x => x.situation == true).ToList();
            ViewBag.valCategories = value5;

            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult WeatherCart()
        {
            return View();
        }

        public ActionResult LinqCart()
        {
            var value1 = db.books.Count();
            ViewBag.numbersOfBooks = value1;

            var value2 = db.members.Count();
            ViewBag.membersOfMembers = value2;

            var value3 = db.penalties.Sum(p => p.price);
            ViewBag.priceInCase = value3;

            var value4 = db.books.Where(b=>b.situation == false).Count();
            ViewBag.numberOfLendBook = value4;

            var value5 = db.categories.Count();
            ViewBag.numbersOfCategories = value5;

            var value6 = db.contact.Count();
            ViewBag.totalMessageCount = value6;

            var value7 = db.WritedMaxBookAuthor().FirstOrDefault(); // aynı sayıda kitapa sahip 2 yazar olabilir. en üsttekini almalıyız.
            ViewBag.val7 = value7;

            // en iyi yayınevi

            // select top1 publisher,count(*) from books group by publisher order by count(*) desc
            var value8 = db.books.GroupBy(b => b.publisher).OrderByDescending(p => p.Count()).
                Select(pub => pub.Key).FirstOrDefault();
            ViewBag.val8 = value8;

            var value9 = db.events.Where(e => e.get_date == DateTime.Now).Count();
            ViewBag.val9 = value9;

            var value10 = db.bestMember().FirstOrDefault();
            ViewBag.val10 = value10;

            var value11 = db.bestBook().FirstOrDefault();
            ViewBag.val11 = value11;

            var value12 = db.bestPerconnel().FirstOrDefault();
            ViewBag.val12 = value12;

            return View();
        }
    }
}