﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LupangoCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var list = new List<user>();
            using (var db = new imdbsysEntities())
            {
                list = db.user.ToList();
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user u)
        {
            using (var db = new imdbsysEntities())
            {
                var newUser = new user();
                newUser.username = u.username;
                newUser.password = u.password;

                db.user.Add(newUser);
                db.SaveChanges();

                TempData["msg"] = $"Added {newUser.username} Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var u = new user();
            using (var db = new imdbsysEntities())
            {
                u = db.user.Find(id);
            }
            return View(u);
        }
        [HttpPost]

        public ActionResult Update(user u)
        {
            using (var db = new imdbsysEntities())
            {
                var newUser = db.user.Find(u.id);
                newUser.username = u.username;
                newUser.password = u.password;

                db.SaveChanges();

                TempData["msg"] = $"Updated {newUser.username} Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var u = new user();
            using (var db = new imdbsysEntities())
            {
                u = db.user.Find(id);
                db.user.Remove(u);
                db.SaveChanges();

                TempData["msg"] = $"Deleted {u.username} Successfully";
            }
            return RedirectToAction("Index");
            
        }
    }
}