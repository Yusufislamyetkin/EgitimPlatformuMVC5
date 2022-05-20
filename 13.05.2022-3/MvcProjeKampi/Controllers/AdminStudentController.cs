using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminStudentController : Controller
    {
        StudentManager sm = new StudentManager(new EFStudentDal());

        // GET: AdminWriter
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listing()
        {
            var ListValues = sm.GetList();
            return View(ListValues);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student s)
        {
            StudentValidatior Wv = new StudentValidatior();
            ValidationResult reslt = Wv.Validate(s);
            if (reslt.IsValid)
            {
                s.StudentStatus = true;
                s.MemeberShipDate = DateTime.Parse( DateTime.Now.ToLongTimeString());
               
                sm.WAdd(s);
                return RedirectToAction("Listing");

            }
            else
            {
                foreach (var item in reslt.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

               
            }


            return View();
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var values = sm.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult EditStudent(Student s)
        {
            StudentValidatior Wv = new StudentValidatior();
            ValidationResult reslt = Wv.Validate(s);

            if (reslt.IsValid)
            {
                s.StudentStatus = true;
                s.MemeberShipDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
                sm.WUpdate(s);
                return RedirectToAction("Listing");
            }
            else
            {
                foreach (var item in reslt.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    
                }
                return View();
            }
          

           
        }


        //public ActionResult DeleteWriter(int id)
        //{
        //    var getirilendegerler = vm.GetByID(id);
        //    vm.WDelete(getirilendegerler);
        //    return RedirectToAction("Listing");

        //}
    }
}