using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
   
    public class AboutController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            
            var aboutList = db.TblAbouts.ToList();
            return View(aboutList);
        }

        public ActionResult DeleteAbout(int id)
        {
            var about = db.TblAbouts.Find(id);

            db.TblAbouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout about)
        {
            db.TblAbouts.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]

        public ActionResult UpdateAbout(TblAbout about)
        {

            var value = db.TblAbouts.FirstOrDefault(x=>x.AboutID == about.AboutID);

            value.FirstName = about.FirstName;
            value.Job = about.Job;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            db.SaveChanges();

            return RedirectToAction("Index");


        }





    }
}