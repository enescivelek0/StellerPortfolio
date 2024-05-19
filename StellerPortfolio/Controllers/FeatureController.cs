using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class FeatureController : Controller
    {
       StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeature feature)
        {
            db.TblFeatures.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature feature)
        {
            var value = db.TblFeatures.Find(feature.FeatureID);
            value.FirstName = feature.FirstName;
            value.Title=feature.Title;
            value.Job = feature.Job;
            value.ImageUrl = feature.ImageUrl;
            value.CvDownloadUrl = feature.CvDownloadUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}