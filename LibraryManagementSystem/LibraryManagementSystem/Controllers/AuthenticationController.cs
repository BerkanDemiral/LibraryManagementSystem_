﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem.Models.Entity;
using System.Web.Security; // otantike işlemleri için kullanacağımız kütüphanemiz
namespace LibraryManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        DBLIBRARYEntities db = new DBLIBRARYEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(members member)
        {
            var values = db.members.FirstOrDefault(m => m.email == member.email && m.password == member.password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.email, false);
                return RedirectToAction("/MemberPanel/Index/");
            }
            else
            {
                return View();
            }

            
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(members member)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }

            db.members.Add(member);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}