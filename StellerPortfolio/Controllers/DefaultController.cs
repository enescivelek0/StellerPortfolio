using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            ViewBag.project = db.TblProjects.Count();
            ViewBag.testimonial = db.TblTestimonials.Count();
            ViewBag.skill = db.TblSkills.Count();
            var values = db.TblFeatures.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage message)
        {
            message.IsRead = false;
            db.TblMessages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x=>x.ServiceStatus==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values); 
        }

        public PartialViewResult DefaultProjectPartial()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultContactInfoPartial()
        {
            var values = db.TblContacts.ToList();
            return PartialView(values);
        }

        public PartialViewResult UILayoutFooterPartial()
        {
            var values = db.TblSocialMedias.ToList();
            return PartialView(values);
        }


        public PartialViewResult DefaultSocialMediaPartial()
        {
            var values = db.TblSocialMedias.ToList();
            return PartialView(values);
        }
    }
}