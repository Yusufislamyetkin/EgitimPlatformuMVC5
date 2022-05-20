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
    public class GraphsController : Controller
    {
        StudentManager sm = new StudentManager(new EFStudentDal());
        StudentCourseFallowManager escf = new StudentCourseFallowManager(new EFStudentCourseFallowDal());
        TytDenemeManager tdm = new TytDenemeManager(new EFTytdenemeDal());
        AytDenemeManager adm = new AytDenemeManager(new EFAytdenemeDal());
        // GET: Graphs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TytCourseGraphs()
        {

            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

            var tytbiyo = escf.TYTBİYOKwhereList(studentid);
            var tytcog = escf.TYTCOGwhereList(studentid);
            var tytdin = escf.TYTDİNKwhereList(studentid);
            var tytfel = escf.TYTFELwhereList(studentid);
            var tytfiz = escf.TYTFİZKwhereList(studentid);
            var tytgeo = escf.TYTGEOKwhereList(studentid);
            var tytkim = escf.TYTKİMwhereList(studentid);
            var tytmat = escf.TYTMATKwhereList(studentid);
            var tyttar = escf.TYTTARwhereList(studentid);
            var tytturk = escf.TYTTURKwhereList(studentid);

            #region Tyt
            int tytfinishedcountbiyo = 0;
            int tytnotfinishedcountbiyo = 0;
            int tytstaticticbiyo = 0;
            foreach (var item in tytbiyo)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountbiyo++;
                }
                else
                {
                    tytnotfinishedcountbiyo++;
                }



            }
            tytstaticticbiyo = 100 / (tytfinishedcountbiyo + tytnotfinishedcountbiyo) * tytfinishedcountbiyo;
            ViewBag.tytstaticticbiyo = Convert.ToInt32(tytstaticticbiyo);
            ViewBag.tytnotfinishedcountbiyo = tytnotfinishedcountbiyo;
            ViewBag.tytfinishedcountbiyo = tytfinishedcountbiyo;

            decimal tytfinishedcountcog = 0;
            decimal tytnotfinishedcountcog = 0;
            decimal tytstaticticcog = 0;
            foreach (var item in tytcog)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountcog++;
                }
                else
                {
                    tytnotfinishedcountcog++;
                }



            }
            tytstaticticcog = (100 / (tytfinishedcountcog + tytnotfinishedcountcog)) * tytfinishedcountcog;
            ViewBag.tytstaticticcog = Convert.ToInt32(tytstaticticcog);
            ViewBag.tytnotfinishedcountcog = tytnotfinishedcountcog;
            ViewBag.tytfinishedcountcog = tytfinishedcountcog;


            decimal tytfinishedcountdin = 0;
            decimal tytnotfinishedcountdin = 0;
            decimal tytstaticticdin = 0;
            foreach (var item in tytdin)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountdin++;
                }
                else
                {
                    tytnotfinishedcountdin++;
                }



            }
            tytstaticticdin = 100 / (tytfinishedcountdin + tytnotfinishedcountdin) * tytfinishedcountdin;
            ViewBag.tytstaticticdin = Convert.ToInt32(tytstaticticdin);
            ViewBag.tytnotfinishedcountdin = tytnotfinishedcountdin;
            ViewBag.tytfinishedcountdin = tytfinishedcountdin;


            decimal tytfinishedcountfel = 0;
            decimal tytnotfinishedcountfel = 0;
            decimal tytstaticticfel = 0;
            foreach (var item in tytfel)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountfel++;
                }
                else
                {
                    tytnotfinishedcountfel++;
                }



            }
            tytstaticticfel = 100 / (tytfinishedcountfel + tytnotfinishedcountfel) * tytfinishedcountfel;
            ViewBag.tytstaticticfel = Convert.ToInt32(tytstaticticfel);
            ViewBag.tytnotfinishedcountfel = tytnotfinishedcountfel;
            ViewBag.tytfinishedcountfel = tytfinishedcountfel;


            decimal tytfinishedcountfiz = 0;
            decimal tytnotfinishedcountfiz = 0;
            decimal tytstaticticfiz = 0;
            foreach (var item in tytfiz)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountfiz++;
                }
                else
                {
                    tytnotfinishedcountfiz++;
                }



            }
            tytstaticticfiz = 100 / (tytfinishedcountfiz + tytnotfinishedcountfiz) * tytfinishedcountfiz;
            ViewBag.tytstaticticfiz = Convert.ToInt32(tytstaticticfiz);
            ViewBag.tytnotfinishedcountfiz = tytnotfinishedcountfiz;
            ViewBag.tytfinishedcountfiz = tytfinishedcountfiz;


            decimal tytfinishedcountgeo = 0;
            decimal tytnotfinishedcountgeo = 0;
            decimal tytstaticticgeo = 0;
            foreach (var item in tytgeo)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountgeo++;
                }
                else
                {
                    tytnotfinishedcountgeo++;
                }



            }

            tytstaticticgeo = 100 / (tytfinishedcountgeo + tytnotfinishedcountgeo) * tytfinishedcountgeo;



            ViewBag.tytstaticticgeo = Convert.ToInt32(tytstaticticgeo);
            ViewBag.tytnotfinishedcountgeo = tytnotfinishedcountgeo;
            ViewBag.tytfinishedcountgeo = tytfinishedcountgeo;


            decimal tytfinishedcountkim = 0;
            decimal tytnotfinishedcountkim = 0;
            decimal tytstatictickim = 0;
            foreach (var item in tytkim)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountkim++;
                }
                else
                {
                    tytnotfinishedcountkim++;
                }



            }
            tytstatictickim = 100 / (tytfinishedcountkim + tytnotfinishedcountkim) * tytfinishedcountkim;
            ViewBag.tytstatictickim = Convert.ToInt32(tytstatictickim);
            ViewBag.tytnotfinishedcountkim = tytnotfinishedcountkim;
            ViewBag.tytfinishedcountkim = tytfinishedcountkim;


            decimal tytfinishedcountmat = 0;
            decimal tytnotfinishedcountmat = 0;
            decimal tytstaticticmat = 0;
            foreach (var item in tytmat)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountmat++;
                }
                else
                {
                    tytnotfinishedcountmat++;
                }



            }
            tytstaticticmat = (100 / (tytfinishedcountmat + tytnotfinishedcountmat)) * tytfinishedcountmat;
            ViewBag.tytstaticticmat = Convert.ToInt32(tytstaticticmat);
            ViewBag.tytnotfinishedcountmat = tytnotfinishedcountmat;
            ViewBag.tytfinishedcountmat = tytfinishedcountmat;


            decimal tytfinishedcounttar = 0;
            decimal tytnotfinishedcounttar = 0;
            decimal tytstatictictar = 0;
            foreach (var item in tyttar)
            {
                if (item.Durum == true)
                {
                    tytfinishedcounttar++;
                }
                else
                {
                    tytnotfinishedcounttar++;
                }



            }
            tytstatictictar = 100 / (tytfinishedcounttar + tytnotfinishedcounttar) * tytfinishedcounttar;
            ViewBag.tytstatictictar = Convert.ToInt32(tytstatictictar);
            ViewBag.tytnotfinishedcounttar = tytnotfinishedcounttar;
            ViewBag.tytfinishedcounttar = tytfinishedcounttar;



            decimal tytfinishedcountturk = 0;
            decimal tytnotfinishedcountturk = 0;
            decimal tytstaticticturk = 0;
            foreach (var item in tytturk)
            {
                if (item.Durum == true)
                {
                    tytfinishedcountturk++;
                }
                else
                {
                    tytnotfinishedcountturk++;
                }



            }
            tytstaticticturk = 100 / (tytfinishedcountturk + tytnotfinishedcountturk) * tytfinishedcountturk;
            ViewBag.tytstaticticturk = Convert.ToInt32(tytstaticticturk);
            ViewBag.tytnotfinishedcountturk = tytnotfinishedcountturk;
            ViewBag.tytfinishedcountturk = tytfinishedcountturk;
            #endregion

            var aytbiyo = escf.AYTBİYOKwhereList(studentid);
            var aytcog = escf.AYTCOGwhereList(studentid);
            var aytdin = escf.AYTDİNKwhereList(studentid);
            var aytfel = escf.AYTFELwhereList(studentid);
            var aytfiz = escf.AYTFİZKwhereList(studentid);
            var aytgeo = escf.AYTGEOKwhereList(studentid);
            var aytkim = escf.AYTKİMwhereList(studentid);
            var aytmat = escf.AYTMATKwhereList(studentid);
            var ayttar = escf.AYTTARwhereList(studentid);
            var aytedeb = escf.AYTEDEBwhereList(studentid);


            #region Ayt






            int aytfinishedcountbiyo = 0;
            int aytnotfinishedcountbiyo = 0;
            int aytstaticticbiyo = 0;
            foreach (var item in aytbiyo)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountbiyo++;
                }
                else
                {
                    aytnotfinishedcountbiyo++;
                }



            }
            aytstaticticbiyo = 100 / (aytfinishedcountbiyo + aytnotfinishedcountbiyo) * aytfinishedcountbiyo;
            ViewBag.aytstaticticbiyo = Convert.ToInt32(aytstaticticbiyo);
            ViewBag.aytnotfinishedcountbiyo = aytnotfinishedcountbiyo;
            ViewBag.aytfinishedcountbiyo = aytfinishedcountbiyo;

            decimal aytfinishedcountcog = 0;
            decimal aytnotfinishedcountcog = 0;
            decimal aytstaticticcog = 0;
            foreach (var item in aytcog)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountcog++;
                }
                else
                {
                    aytnotfinishedcountcog++;
                }



            }
            aytstaticticcog = (100 / (aytfinishedcountcog + aytnotfinishedcountcog)) * aytfinishedcountcog;
            ViewBag.aytstaticticcog = Convert.ToInt32(aytstaticticcog);
            ViewBag.aytnotfinishedcountcog = aytnotfinishedcountcog;
            ViewBag.aytfinishedcountcog = aytfinishedcountcog;


            decimal aytfinishedcountdin = 0;
            decimal aytnotfinishedcountdin = 0;
            decimal aytstaticticdin = 0;
            foreach (var item in aytdin)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountdin++;
                }
                else
                {
                    aytnotfinishedcountdin++;
                }



            }
            aytstaticticdin = 100 / (aytfinishedcountdin + aytnotfinishedcountdin) * aytfinishedcountdin;
            ViewBag.aytstaticticdin = Convert.ToInt32(aytstaticticdin);
            ViewBag.aytnotfinishedcountdin = aytnotfinishedcountdin;
            ViewBag.aytfinishedcountdin = aytfinishedcountdin;


            decimal aytfinishedcountfel = 0;
            decimal aytnotfinishedcountfel = 0;
            decimal aytstaticticfel = 0;
            foreach (var item in aytfel)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountfel++;
                }
                else
                {
                    aytnotfinishedcountfel++;
                }



            }
            aytstaticticfel = 100 / (aytfinishedcountfel + aytnotfinishedcountfel) * aytfinishedcountfel;
            ViewBag.aytstaticticfel = Convert.ToInt32(aytstaticticfel);
            ViewBag.aytnotfinishedcountfel = aytnotfinishedcountfel;
            ViewBag.aytfinishedcountfel = aytfinishedcountfel;


            decimal aytfinishedcountfiz = 0;
            decimal aytnotfinishedcountfiz = 0;
            decimal aytstaticticfiz = 0;
            foreach (var item in aytfiz)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountfiz++;
                }
                else
                {
                    aytnotfinishedcountfiz++;
                }



            }
            aytstaticticfiz = 100 / (aytfinishedcountfiz + aytnotfinishedcountfiz) * aytfinishedcountfiz;
            ViewBag.aytstaticticfiz = Convert.ToInt32(aytstaticticfiz);
            ViewBag.aytnotfinishedcountfiz = aytnotfinishedcountfiz;
            ViewBag.aytfinishedcountfiz = aytfinishedcountfiz;


            decimal aytfinishedcountgeo = 0;
            decimal aytnotfinishedcountgeo = 0;
            decimal aytstaticticgeo = 0;
            foreach (var item in aytgeo)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountgeo++;
                }
                else
                {
                    aytnotfinishedcountgeo++;
                }



            }

            aytstaticticgeo = 100 / (aytfinishedcountgeo + aytnotfinishedcountgeo) * aytfinishedcountgeo;



            ViewBag.aytstaticticgeo = Convert.ToInt32(aytstaticticgeo);
            ViewBag.aytnotfinishedcountgeo = aytnotfinishedcountgeo;
            ViewBag.aytfinishedcountgeo = aytfinishedcountgeo;


            decimal aytfinishedcountkim = 0;
            decimal aytnotfinishedcountkim = 0;
            decimal aytstatictickim = 0;
            foreach (var item in aytkim)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountkim++;
                }
                else
                {
                    aytnotfinishedcountkim++;
                }



            }
            aytstatictickim = 100 / (aytfinishedcountkim + aytnotfinishedcountkim) * aytfinishedcountkim;
            ViewBag.aytstatictickim = Convert.ToInt32(aytstatictickim);
            ViewBag.aytnotfinishedcountkim = aytnotfinishedcountkim;
            ViewBag.aytfinishedcountkim = aytfinishedcountkim;


            decimal aytfinishedcountmat = 0;
            decimal aytnotfinishedcountmat = 0;
            decimal aytstaticticmat = 0;
            foreach (var item in aytmat)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountmat++;
                }
                else
                {
                    aytnotfinishedcountmat++;
                }



            }
            aytstaticticmat = (100 / (aytfinishedcountmat + aytnotfinishedcountmat)) * aytfinishedcountmat;
            ViewBag.aytstaticticmat = Convert.ToInt32(aytstaticticmat);
            ViewBag.aytnotfinishedcountmat = aytnotfinishedcountmat;
            ViewBag.aytfinishedcountmat = aytfinishedcountmat;


            decimal aytfinishedcounttar = 0;
            decimal aytnotfinishedcounttar = 0;
            decimal aytstatictictar = 0;
            foreach (var item in ayttar)
            {
                if (item.Durum == true)
                {
                    aytfinishedcounttar++;
                }
                else
                {
                    aytnotfinishedcounttar++;
                }



            }
            aytstatictictar = 100 / (aytfinishedcounttar + aytnotfinishedcounttar) * aytfinishedcounttar;
            ViewBag.aytstatictictar = Convert.ToInt32(aytstatictictar);
            ViewBag.aytnotfinishedcounttar = aytnotfinishedcounttar;
            ViewBag.aytfinishedcounttar = aytfinishedcounttar;



            decimal aytfinishedcountedeb = 0;
            decimal aytnotfinishedcountedeb = 0;
            decimal aytstaticticedeb = 0;
            foreach (var item in aytedeb)
            {
                if (item.Durum == true)
                {
                    aytfinishedcountedeb++;
                }
                else
                {
                    aytnotfinishedcountedeb++;
                }



            }
            aytstaticticedeb = 100 / (aytfinishedcountedeb + aytnotfinishedcountedeb) * aytfinishedcountedeb;
            ViewBag.aytstaticticedeb = Convert.ToInt32(aytstaticticedeb);
            ViewBag.aytnotfinishedcountedeb = aytnotfinishedcountedeb;
            ViewBag.aytfinishedcountedeb = aytfinishedcountedeb;
            #endregion


            return View();
        }

        public ActionResult TrialGraphs()
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;
      


            var list = tdm.GetListStudentWhere(studentid);
           var forpuan =  list.OrderBy(x => x.TopNet).ToList();
            forpuan.Reverse();

            List<TytDeneme> studenttriallist = new List<TytDeneme>();

            for (int i = 0; i < 5; i++)
            {
                if (forpuan.Count > i)
                {
                    studenttriallist.Add(forpuan[i]);
                }
            }
      
           
           
            ViewBag.studenttriallist = studenttriallist;

            //burası ayt

            var list2 = adm.GetListStudentWhere(studentid);
            var forpuan2 = list2.OrderBy(x => x.TopNet).ToList();
            forpuan2.Reverse();

            List<AytDeneme> studenttriallist2 = new List<AytDeneme>();

            for (int i = 0; i < 5; i++)
            {
                if (forpuan2.Count > i)
                {
                    studenttriallist2.Add(forpuan2[i]);
                }
            }
            ViewBag.studenttriallist2 = studenttriallist2;

            return View();

        }
    }
}