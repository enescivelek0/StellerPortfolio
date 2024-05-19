using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class SkillController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();

        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkill skill)
        {
           
            db.TblSkills.Add(skill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill skill)
        {
            var value = db.TblSkills.Find(skill.SkillID);

            value.SkillName= skill.SkillName;
            value.Value= skill.Value;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}