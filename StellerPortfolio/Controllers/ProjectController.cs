using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProject project)
        {
            db.TblProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}