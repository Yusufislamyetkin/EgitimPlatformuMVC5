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
    public class CalendarController : Controller
    {
        CalendarManager cm = new CalendarManager(new EFCalendarDal());
        StudentManager sm = new StudentManager(new EFStudentDal());
        // GET: Calendar

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(calendar calendar)
        {
            string p;
            p = (string)Session["StudentEmail"];

            var StudentValue = sm.GetBySession(p);
            calendar.CalendarStatus = false;
            calendar.StudentID = StudentValue.StudentID;

            CalendarValidator calendarValidator = new CalendarValidator();
            ValidationResult results = calendarValidator.Validate(calendar);

            if (results.IsValid)
            {
                cm.AddValue(calendar);
                TempData["AlertMessageCalendar"] = "Planınız Oluşturuldu";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }

            }
            return View();



           
        }


        public ActionResult SeeCalendar()
        {
            string p;
            p = (string)Session["StudentEmail"];

            var StudentValue = sm.GetBySession(p);
            int studentıd = StudentValue.StudentID;
            List<calendar> ıdlisttrue = cm.GetByIDStudentTrue(studentıd);
            List<calendar> ıdlistfalse = cm.GetByIDStudentFalse(studentıd);

            ViewBag.ıdlisttrue = ıdlisttrue;
            ViewBag.ıdlistfalse = ıdlistfalse;

            return View();
        }

        public ActionResult ConvertToTrueCalendar(int id)
        {

           var converttrue = cm.GetByID(id);
            converttrue.CalendarStatus = true;
            cm.calendarUpdate(converttrue);
            return RedirectToAction("SeeCalendar");
        }

        public ActionResult ConvertToFalseCalendar(int id)
        {
            var convertfalse = cm.GetByID(id);
            convertfalse.CalendarStatus = false;
            cm.calendarUpdate(convertfalse);
            return RedirectToAction("SeeCalendar");

        }
        public ActionResult Delete(int id)
        {
            var value = cm.GetByID(id);

            cm.calendarDelete(value);
            return RedirectToAction("SeeCalendar");

        }


    }
}