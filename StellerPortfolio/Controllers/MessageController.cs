using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class MessageController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblMessages.Where(x=>x.IsRead==false).ToList();
            return View(values);
        }

        public ActionResult MessageDetail(int id)
        {
            var message = db.TblMessages.Find(id);
            message.IsRead = true;
            db.SaveChanges();
            return View(message);
        }

        public ActionResult ReadMessages()
        {
            var values  = db.TblMessages.Where(x=>x.IsRead==true).ToList();
            return View(values);
        }


    }
}