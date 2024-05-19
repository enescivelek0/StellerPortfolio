using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia SocialMedia)
        {

            db.TblSocialMedias.Add(SocialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia SocialMedia)
        {
            var value = db.TblSocialMedias.Find(SocialMedia.SocialMediaID);
            value.SocialMediaName = SocialMedia.SocialMediaName;
            value.Icon=SocialMedia.Icon;
            value.LinkUrl=SocialMedia.LinkUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}