using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellerPortfolio.Controllers
{
    public class ContactController : Controller
    {
        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();
        public ActionResult Index()
        {
            var values = db.TblContacts.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContact(TblContact contact)
        {
            db.TblContacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact contact)
        {
            var value = db.TblContacts.Find(contact.ContactID);
            value.Phone= contact.Phone;
            value.Address= contact.Address;
            value.Email=contact.Email;
            value.MapUrl = contact.MapUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}