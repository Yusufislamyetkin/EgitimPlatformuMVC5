using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    
    public class TrialController : Controller
    {
        // GET: Trial

        AytDenemeManager adm = new AytDenemeManager(new EFAytdenemeDal());
        TytDenemeManager tdm = new TytDenemeManager(new EFTytdenemeDal());
        StudentManager sm = new StudentManager(new EFStudentDal());

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TytListing(int sayfa = 1)
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;
            var list = tdm.GetListStudentWhere(studentid);
            var lstvalue = list.ToList().ToPagedList(sayfa, 5);
            return View(lstvalue);
        }
        public ActionResult TytTrialDelete(int id)
        {
            var value = tdm.GetByID(id);
            tdm.WDelete(value);
            TempData["AlertMessageDelete"] = "Silme işlemi tamamnlandı";
            return RedirectToAction("TytListing");
        }
        [HttpGet]
        public ActionResult TytTrialUpdate(int id)
        {
            var list = tdm.GetByID(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult TytTrialUpdate(TytDeneme TytDeneme)
        {
            try
            {

                TYTDenemeValidatior tytDenemeValidatior = new TYTDenemeValidatior();
                ValidationResult results = tytDenemeValidatior.Validate(TytDeneme);

                if (results.IsValid)
                {
                    var changevalue = tdm.GetByID(TytDeneme.ID);

                    changevalue.FenNet = TytDeneme.FenNet;
                    changevalue.SosNet = TytDeneme.SosNet;
                    changevalue.MatNet = TytDeneme.MatNet;
                    changevalue.TurkNet = TytDeneme.TurkNet;
                    changevalue.Yayın = TytDeneme.Yayın; ;
                    changevalue.Puan = TytDeneme.Puan; ;
                    changevalue.Tarih = TytDeneme.Tarih; ;

                    tdm.WUpdate(changevalue);

                    TempData["AlertMessage"] = "Güncelleme Tamamlandı.";
                    return RedirectToAction("TytListing");
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
            catch 
            {
                return RedirectToAction("TytListing");
            }

        }


        [HttpGet]
        public ActionResult TytTrialAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TytTrialAdd(TytDeneme tytDeneme)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];
                var session = sm.GetBySession(p);
                int studentid = session.StudentID;
                tytDeneme.StudentID = studentid;
               tytDeneme.TopNet =  tytDeneme.FenNet + tytDeneme.SosNet + tytDeneme.TurkNet + tytDeneme.MatNet;

                TYTDenemeValidatior tytDenemeValidatior = new TYTDenemeValidatior();
                ValidationResult results = tytDenemeValidatior.Validate(tytDeneme);

                if (results.IsValid)
                {
                    tdm.WAdd(tytDeneme);
                    return RedirectToAction("TytListing");
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
            catch
            {

                return RedirectToAction("TytListing");
            }
  

       
        }

        public ActionResult AytListing(int sayfa = 1)
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;
            var list = adm.GetListStudentWhere(studentid);
            var lstvalue = list.ToList().ToPagedList(sayfa, 5);

            return View(lstvalue);
        }
        public ActionResult AytTrialDelete(int id)
        {
            var value = adm.GetByID(id);
            adm.WDelete(value);
            TempData["AlertMessageDelete"] = "Silme işlemi tamamnlandı";
            return RedirectToAction("AytListing");
        }
        [HttpGet]
        public ActionResult AytTrialAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AytTrialAdd(AytDeneme aytDeneme)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];
                var session = sm.GetBySession(p);
                int studentid = session.StudentID;
                aytDeneme.StudentID = studentid;

                AYTDenemeValidator AytDenemeValidatiorr = new AYTDenemeValidator();
                ValidationResult results = AytDenemeValidatiorr.Validate(aytDeneme);

                if (results.IsValid)
                {
                    adm.WAdd(aytDeneme);
                    return RedirectToAction("AytListing");
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
            catch 
            {
                return RedirectToAction("AytListing");
            }
          
        }
        [HttpGet]
        public ActionResult AytTrialUpdate(int id)
        {
            var list = adm.GetByID(id);
            return View(list);
        }
        [HttpPost]
        public ActionResult AytTrialUpdate(AytDeneme AytDeneme)
        {

            try
            {
                AYTDenemeValidator AytDenemeValidatiorr = new AYTDenemeValidator();
                ValidationResult results = AytDenemeValidatiorr.Validate(AytDeneme);

                if (results.IsValid)
                {
                    var changevalue = tdm.GetByID(AytDeneme.ID);

                    changevalue.FenNet = AytDeneme.FenNet;
                    changevalue.SosNet = AytDeneme.SosNet;
                    changevalue.MatNet = AytDeneme.MatNet;
                    changevalue.TurkNet = AytDeneme.EdebNet;
                    changevalue.Yayın = AytDeneme.Yayın;
                    changevalue.Puan = AytDeneme.Puan;
                    changevalue.Tarih = AytDeneme.Tarih;

                    tdm.WUpdate(changevalue);
                    TempData["AlertMessage"] = "Güncelleme Tamamlandı.";
                    return RedirectToAction("AytListing");
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
            catch (Exception)
            {

                return RedirectToAction("AytListing");
            }
           
        }

    }
}