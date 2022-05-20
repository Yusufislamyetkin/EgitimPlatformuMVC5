using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StudentTopicsController : Controller
    {
        StudentManager sm = new StudentManager(new EFStudentDal());
        StudentCourseFallowManager scfm = new StudentCourseFallowManager(new EFStudentCourseFallowDal());
        StudentLoginManager wlm = new StudentLoginManager(new EFStudentLoginDal());
        // GET: StudentTopics
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TYTFinished(int id,int sayfa)
        {
            var selectRow = scfm.GetByID(id);
            scfm.LessonFinished(selectRow);
            DateTime date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            selectRow.Tarih = date;
            scfm.Update(selectRow);
            int dgr = 0;
            if (selectRow.Ders == "TYTTURK")
            {
                dgr = 1;
            }
            else if (selectRow.Ders == "TYTMAT")
            {
                dgr = 2;
            }
            else if (selectRow.Ders == "TYTGEO")
            {
                dgr = 3;
            }
            else if (selectRow.Ders == "TYTFİZ")
            {
                dgr = 4;
            }
            else if (selectRow.Ders == "TYTKİM")
            {
                dgr = 5;
            }
            else if (selectRow.Ders == "TYTBİYO")
            {
                dgr = 6;
            }
            else if (selectRow.Ders == "TYTTAR")
            {
                dgr = 7;
            }
            else if (selectRow.Ders == "TYTCOG")
            {
                dgr = 8;
            }
            else if (selectRow.Ders == "TYTDİN")
            {
                dgr = 9;
            }
            else if (selectRow.Ders == "TYTFEL")
            {
                dgr = 10;
            }

            return RedirectToAction("StudentTYT", new { id = dgr , sayfa = sayfa});
        
        }

        public ActionResult TYTNotFinished(int id, int sayfa)
        {
            var selectRow = scfm.GetByID(id);
            DateTime date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            selectRow.Tarih = date;
            scfm.LessonNotFinished(selectRow);
            int dgr = 0;
            if (selectRow.Ders == "TYTTURK")
            {
                dgr = 1;
            }
            else if (selectRow.Ders == "TYTMAT")
            {
                dgr = 2;
            }
            else if (selectRow.Ders == "TYTGEO")
            {
                dgr = 3;
            }
            else if (selectRow.Ders == "TYTFİZ")
            {
                dgr = 4;
            }
            else if (selectRow.Ders == "TYTKİM")
            {
                dgr = 5;
            }
            else if (selectRow.Ders == "TYTBİYO")
            {
                dgr = 6;
            }
            else if (selectRow.Ders == "TYTTAR")
            {
                dgr = 7;
            }
            else if (selectRow.Ders == "TYTCOG")
            {
                dgr = 8;
            }
            else if (selectRow.Ders == "TYTDİN")
            {
                dgr = 9;
            }
            else if (selectRow.Ders == "TYTFEL")
            {
                dgr = 10;
            }

            return RedirectToAction("StudentTYT", new { id = dgr, sayfa = sayfa });
        }

     
        public ActionResult StudentTYT(int id,int sayfa = 1 )
        {

            string p;
            p = (string)Session["StudentEmail"];

            var StudentValue = sm.GetBySession(p);

            int sid = StudentValue.StudentID;

            List<CourseFallow> lst = new List<CourseFallow>();
            switch (id)
            {
                case 1:
                lst = scfm.TYTTURKwhereList(sid);
                   
                    ViewBag.dgr = 1;
                    break;

                case 2:
                   lst = scfm.TYTMATKwhereList(sid);
                    
                    ViewBag.dgr = 2;
                    break;
                case 3:
                    lst = scfm.TYTGEOKwhereList(sid);
                    ViewBag.dgr = 3;
                    break;
                case 4:
                    lst = scfm.TYTFİZKwhereList(sid);
                    ViewBag.dgr = 4;
                    break;
                case 5:
                    lst = scfm.TYTKİMwhereList(sid);
                    ViewBag.dgr = 5;
                    break;
                case 6:
                    lst = scfm.TYTBİYOKwhereList(sid);
                    ViewBag.dgr = 6;
                    break;
                case 7:
                    lst = scfm.TYTTARwhereList(sid);
                    ViewBag.dgr = 7;
                    break;
                case 8:
                    lst = scfm.TYTCOGwhereList(sid);
                    ViewBag.dgr = 8;
                    break;
                case 9:
                    lst = scfm.TYTDİNKwhereList(sid);
                    ViewBag.dgr = 9;
                    break;
                case 10:
                    lst = scfm.TYTFELwhereList(sid);
                    ViewBag.dgr = 10;
                    break;

            }

          var lstvalue =  lst.ToList().ToPagedList(sayfa, 5);
            ViewBag.sayfanumber = sayfa;
            return View(lstvalue);
        }

        public ActionResult StudentTYTCourse()
        {
            return View();
        }



        public ActionResult StudentAYTCourse()
        {
            return View();
        }

        public ActionResult StudentAYT(int id, int sayfa = 1)
        {

            string p;
            p = (string)Session["StudentEmail"];

            var StudentValue = sm.GetBySession(p);

            int sid = StudentValue.StudentID;

            List<CourseFallow> lst = new List<CourseFallow>();
            switch (id)
            {
                case 1:
                    lst = scfm.AYTMATKwhereList(sid);
                    ViewBag.dgr = 1;
                    break;

                case 2:
                    lst = scfm.AYTGEOKwhereList(sid);
                    ViewBag.dgr = 2;
                    break;
                case 3:
                    lst = scfm.AYTFİZKwhereList(sid);
                    ViewBag.dgr = 3;
                    break;
                case 4:
                    lst = scfm.AYTKİMwhereList(sid);
                    ViewBag.dgr = 4;
                    break;
                case 5:
                    lst = scfm.AYTBİYOKwhereList(sid);
                    ViewBag.dgr = 5;
                    break;
                case 6:
                    lst = scfm.AYTEDEBwhereList(sid);
                    ViewBag.dgr = 6;
                    break;
                case 7:
                    lst = scfm.AYTTARwhereList(sid);
                    ViewBag.dgr = 7;
                    break;
                case 8:
                    lst = scfm.AYTCOGwhereList(sid);
                    ViewBag.dgr = 8;
                    break;
                case 9:
                    lst = scfm.AYTDİNKwhereList(sid);
                    ViewBag.dgr = 9;
                    break;
                case 10:
                    lst = scfm.AYTFELwhereList(sid);
                    ViewBag.dgr = 10;
                    break;

            }
            var lstvalue = lst.ToList().ToPagedList(sayfa, 5);
            ViewBag.sayfanumber = sayfa;
            return View(lstvalue);
        }

        public ActionResult AYTFinished(int id, int sayfa)
        {
            var selectRow = scfm.GetByID(id);
            scfm.LessonFinished(selectRow);
            DateTime date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            selectRow.Tarih = date;
            scfm.Update(selectRow);
            int dgr = 0;
            if (selectRow.Ders == "AYTMAT")
            {
                dgr = 1;
            }
            else if (selectRow.Ders == "AYTGEO")
            {
                dgr = 2;
            }
            else if (selectRow.Ders == "AYTFİZ")
            {
                dgr = 3;
            }
            else if (selectRow.Ders == "AYTKİM")
            {
                dgr = 4;
            }
            else if (selectRow.Ders == "AYTBİYO")
            {
                dgr = 5;
            }
            else if (selectRow.Ders == "AYTEDEB")
            {
                dgr = 6;
            }
            else if (selectRow.Ders == "AYTTAR")
            {
                dgr = 7;
            }
            else if (selectRow.Ders == "AYTCOG")
            {
                dgr = 8;
            }
            else if (selectRow.Ders == "AYTDİN")
            {
                dgr = 9;
            }
            else if (selectRow.Ders == "AYTFEL")
            {
                dgr = 10;
            }

            return RedirectToAction("StudentAYT", new { id = dgr, sayfa = sayfa });

        }


        public ActionResult AYTNotFinished(int id, int sayfa)
        {
            var selectRow = scfm.GetByID(id);
            DateTime date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            selectRow.Tarih = date;
            scfm.LessonNotFinished(selectRow);
         

            int dgr = 0;
            if (selectRow.Ders == "AYTMAT")
            {
                dgr = 1;
            }
            else if (selectRow.Ders == "AYTGEO")
            {
                dgr = 2;
            }
            else if (selectRow.Ders == "AYTFİZ")
            {
                dgr = 3;
            }
            else if (selectRow.Ders == "AYTKİM")
            {
                dgr = 4;
            }
            else if (selectRow.Ders == "AYTBİYO")
            {
                dgr = 5;
            }
            else if (selectRow.Ders == "AYTEDEB")
            {
                dgr = 6;
            }
            else if (selectRow.Ders == "AYTTAR")
            {
                dgr = 7;
            }
            else if (selectRow.Ders == "AYTCOG")
            {
                dgr = 8;
            }
            else if (selectRow.Ders == "AYTDİN")
            {
                dgr = 9;
            }
            else if (selectRow.Ders == "AYTFEL")
            {
                dgr = 10;
            }

            return RedirectToAction("StudentAYT", new { id = dgr, sayfa = sayfa });
        }

    }
}