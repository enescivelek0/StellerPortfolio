using StellerPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StellerPortfolio.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        StellerAcunMedyaDbEntities1 db = new StellerAcunMedyaDbEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblUser admin)
        {
            var values = db.TblUsers.FirstOrDefault(x=>x.UserName== admin.UserName && x.Password==admin.Password);
            if(values == null)
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName;
                return RedirectToAction("Index", "About");
            }
        }
    }
}