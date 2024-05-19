using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial testimonials)
        {
            db.TblTestimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial testimonials)
        {
            var value = db.TblTestimonials.Find(testimonials.TestimonialID);
            value.FirstName = testimonials.FirstName;
            value.Job = testimonials.Job;
            value.ImageUrl = testimonials.ImageUrl;
            value.Description = testimonials.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}