using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutUsController : Controller
    {
        AboutUsManager aum = new AboutUsManager(new EFAboutUsDal());
        // GET: AboutUs
        public ActionResult Index()
        {
           var aboutusvalue = aum.GetById();
            return View(aboutusvalue);
        }

        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminIndex(AboutUs AboutUs)
        {
            AboutUs.AboutUsID = 1;
            aum.update(AboutUs);
            TempData["Güncelleme"] = "Güncellendi";
            return View();
        }

    }
}