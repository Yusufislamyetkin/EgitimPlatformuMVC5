﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StudentHomepageController : Controller
    {
        // GET: StudentHomepage
        public ActionResult Index()
        {
            return View();
        }
    }
}