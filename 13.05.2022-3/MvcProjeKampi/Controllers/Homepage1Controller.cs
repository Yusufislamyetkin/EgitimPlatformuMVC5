using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    [AllowAnonymous]
    public class Homepage1Controller : Controller
    {
        // GET: Homepage1
        public ActionResult Index()
        {

            return View();

        }
    }
}