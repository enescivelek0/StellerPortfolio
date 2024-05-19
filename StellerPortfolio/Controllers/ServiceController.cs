using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();


        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        public ActionResult DeleteService(int id)
        {
            var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(TblService service)
        {
            service.ServiceStatus = false;
            db.TblServices.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateService(int id)
        {
            var value = db.TblServices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService service)
        {
            var value = db.TblServices.Find(service.ServiceID);
            value.ServiceName = service.ServiceName;
            value.ServiceStatus = true;
            value.ServiceIconUrl= service.ServiceIconUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult MakeActive(int id)
        {
            var value = db.TblServices.Find(id);
            value.ServiceStatus= true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MakePassive(int id)
        {
            var value = db.TblServices.Find(id);
            value.ServiceStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}