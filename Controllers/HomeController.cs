using MathaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathaApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Database1 db = new Database1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User_Table ut)
        {
            db.User_Table.Add(ut);
            db.SaveChanges();
            return RedirectToAction("Display");
        }

        [HttpGet]
        public ActionResult Display()
        {
            var obj = db.User_Table.ToList();
            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var obj = db.User_Table.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Edit(User_Table ut)
        {
            db.Entry(ut).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.User_Table.Find(id);
            return View(obj);
        }
        [HttpPost]
        public ActionResult Delete(User_Table ut)
        {
            db.Entry(ut).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Display");
        }

        public ActionResult Details(int id)
        {
            var obj = db.User_Table.Find(id);
            return View(obj);
        }
        [HttpGet]
        public ActionResult HomePage()
        {            
            return View();
        }

    }
}