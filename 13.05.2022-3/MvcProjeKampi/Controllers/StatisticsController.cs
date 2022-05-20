using BusinessLayer.Conctrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        StudentManager sm = new StudentManager(new EFStudentDal());
        StudentCourseFallowManager escf = new StudentCourseFallowManager(new EFStudentCourseFallowDal());
        TytDenemeManager tdm = new TytDenemeManager(new EFTytdenemeDal());
        AytDenemeManager adm = new AytDenemeManager(new EFAytdenemeDal());
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainCourse()
        {
            return View();
        }

        public ActionResult MainTrialCourse()
        {
            return View();
        }


        private int Max(List<int> sayilar)
        {
            int buyuk = 0;
            if (sayilar.Count == 0)
            {
                return buyuk; 
            }
            else
            {
                buyuk = sayilar[0];

                for (int i = 0; i < sayilar.Count; i++)
                {
                    if (buyuk < sayilar[i])
                    { buyuk = sayilar[i]; }
                }
                return buyuk;
            }
         
        }
        public ActionResult TytTrialStatistic()
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

            var tyttriallist = tdm.GetListStudentWhere(studentid);

            //Score
            List<int> scorelist = new List<int>();

            foreach (var item in tyttriallist)
            {
                
                   scorelist.Add( Convert.ToInt32( item.Puan));
                
            }

            if (scorelist != null)
            {
                ViewBag.scorelist = Max(scorelist);
            }

            //Net
            List<int> netlist = new List<int>();

            foreach (var item in tyttriallist)
            {

                netlist.Add(Convert.ToInt32(item.TopNet));

            }

            if (netlist != null)
            {
                ViewBag.netlist = Max(netlist);
            }

            //Turkçe

            List<int> turkcelist = new List<int>();

            foreach (var item in tyttriallist)
            {

                turkcelist.Add(Convert.ToInt32(item.TurkNet));

            }

            if (turkcelist != null)
            {
                ViewBag.turkcelist = Max(turkcelist);
            }

            //Sosyal

            List<int> sosyallist = new List<int>();

            foreach (var item in tyttriallist)
            {

                sosyallist.Add(Convert.ToInt32(item.SosNet));

            }

            if (sosyallist != null)
            {
                ViewBag.sosyallist = Max(sosyallist);
            }

            //Mat

            List<int> matlist = new List<int>();

            foreach (var item in tyttriallist)
            {

                matlist.Add(Convert.ToInt32(item.MatNet));

            }

            if (matlist != null)
            {
                ViewBag.matlist = Max(matlist);
            }

            //Fen

            List<int> fenlist = new List<int>();

            foreach (var item in tyttriallist)
            {

                fenlist.Add(Convert.ToInt32(item.FenNet));

            }

            if (fenlist != null)
            {
                ViewBag.fenlist = Max(fenlist);
            }

            //Farklı Yayın Evi


            List<string> yayınlist = new List<string>();

            foreach (var item in tyttriallist)
            {

                yayınlist.Add(Convert.ToString(item.Yayın));

            }

            if (yayınlist != null)
            {
              
                ViewBag.yayınevi = yayınlist.Distinct().Count();
            }

          
            


            int trialcount = tyttriallist.Count();
            ViewBag.trialcount = trialcount;







            return View();
        }
        public ActionResult AytTrialStatistic()
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

            var ayttriallist = adm.GetListStudentWhere(studentid);

            //Score
            List<int> scorelist = new List<int>();

            foreach (var item in ayttriallist)
            {

                scorelist.Add(Convert.ToInt32(item.Puan));

            }

            if (scorelist != null)
            {
                ViewBag.scorelist = Max(scorelist);
            }

            //Net
            List<int> netlist = new List<int>();

            foreach (var item in ayttriallist)
            {

                netlist.Add(Convert.ToInt32(item.TopNet));

            }

            if (netlist != null)
            {
                ViewBag.netlist = Max(netlist);
            }

            //Turkçe

            List<int> edeblist = new List<int>();

            foreach (var item in ayttriallist)
            {

                edeblist.Add(Convert.ToInt32(item.EdebNet));

            }

            if (edeblist != null)
            {
                ViewBag.edeblist = Max(edeblist);
            }

            //Sosyal

            List<int> sosyallist = new List<int>();

            foreach (var item in ayttriallist)
            {

                sosyallist.Add(Convert.ToInt32(item.SosNet));

            }

            if (sosyallist != null)
            {
                ViewBag.sosyallist = Max(sosyallist);
            }

            //Mat

            List<int> matlist = new List<int>();

            foreach (var item in ayttriallist)
            {

                matlist.Add(Convert.ToInt32(item.MatNet));

            }

            if (matlist != null)
            {
                ViewBag.matlist = Max(matlist);
            }

            //Fen

            List<int> fenlist = new List<int>();

            foreach (var item in ayttriallist)
            {

                fenlist.Add(Convert.ToInt32(item.FenNet));

            }

            if (fenlist != null)
            {
                ViewBag.fenlist = Max(fenlist);
            }

            //Farklı Yayın Evi


            List<string> yayınlist = new List<string>();

            foreach (var item in ayttriallist)
            {

                yayınlist.Add(Convert.ToString(item.Yayın));

            }

            if (yayınlist != null)
            {

                ViewBag.yayınevi = yayınlist.Distinct().Count();
            }





            //Deneme Sayısı
            int trialcount = ayttriallist.Count();
            ViewBag.trialcount = trialcount;



            return View();
        }

        public ActionResult TytCourseStatistic()
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

            decimal tytfinishedcountbiyo = 0;
            decimal tytnotfinishedcountbiyo = 0;
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
           tytstaticticbiyo = Convert.ToInt32( 100 / (tytfinishedcountbiyo + tytnotfinishedcountbiyo) * tytfinishedcountbiyo);
            ViewBag.tytstaticticbiyo = tytstaticticbiyo;
            ViewBag.tytnotfinishedcountbiyo = tytnotfinishedcountbiyo;
            ViewBag.tytfinishedcountbiyo = tytfinishedcountbiyo;

            decimal tytfinishedcountcog = 0;
            decimal tytnotfinishedcountcog = 0;
            int tytstaticticcog = 0;
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
            tytstaticticcog = Convert.ToInt32(100 / (tytfinishedcountcog + tytnotfinishedcountcog) * tytfinishedcountcog);
            ViewBag.tytstaticticcog = tytstaticticcog;
            ViewBag.tytnotfinishedcountcog = tytnotfinishedcountcog;
            ViewBag.tytfinishedcountcog = tytfinishedcountcog;


            decimal tytfinishedcountdin = 0;
            decimal tytnotfinishedcountdin = 0;
            int tytstaticticdin = 0;
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
            tytstaticticdin = Convert.ToInt32(100 / (tytfinishedcountdin + tytnotfinishedcountdin) * tytfinishedcountdin);
            ViewBag.tytstaticticdin = tytstaticticdin;
            ViewBag.tytnotfinishedcountdin = tytnotfinishedcountdin;
            ViewBag.tytfinishedcountdin = tytfinishedcountdin;


            decimal tytfinishedcountfel = 0;
            decimal tytnotfinishedcountfel = 0;
            int tytstaticticfel = 0;
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
            tytstaticticfel = Convert.ToInt32(100 / (tytfinishedcountfel + tytnotfinishedcountfel) * tytfinishedcountfel);
            ViewBag.tytstaticticfel = tytstaticticfel;
            ViewBag.tytnotfinishedcountfel = tytnotfinishedcountfel;
            ViewBag.tytfinishedcountfel = tytfinishedcountfel;


            decimal tytfinishedcountfiz = 0;
            decimal tytnotfinishedcountfiz = 0;
            int tytstaticticfiz = 0;
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
            tytstaticticfiz = Convert.ToInt32(100 / (tytfinishedcountfiz + tytnotfinishedcountfiz) * tytfinishedcountfiz);
            ViewBag.tytstaticticfiz = tytstaticticfiz;
            ViewBag.tytnotfinishedcountfiz = tytnotfinishedcountfiz;
            ViewBag.tytfinishedcountfiz = tytfinishedcountfiz;


            decimal tytfinishedcountgeo = 0;
            decimal tytnotfinishedcountgeo = 0;
            int tytstaticticgeo = 0;
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
           
                tytstaticticgeo = Convert.ToInt32(100 / (tytfinishedcountgeo + tytnotfinishedcountgeo) * tytfinishedcountgeo);
            
        
          
            ViewBag.tytstaticticgeo = tytstaticticgeo;
            ViewBag.tytnotfinishedcountgeo = tytnotfinishedcountgeo;
            ViewBag.tytfinishedcountgeo = tytfinishedcountgeo;


            decimal tytfinishedcountkim = 0;
            decimal tytnotfinishedcountkim = 0;
            int tytstatictickim = 0;
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
            tytstatictickim = Convert.ToInt32(100 / (tytfinishedcountkim + tytnotfinishedcountkim) * tytfinishedcountkim);
            ViewBag.tytstatictickim = tytstatictickim;
            ViewBag.tytnotfinishedcountkim = tytnotfinishedcountkim;
            ViewBag.tytfinishedcountkim = tytfinishedcountkim;


            decimal tytfinishedcountmat = 0;
            decimal tytnotfinishedcountmat = 0;
            int tytstaticticmat = 0;
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
            tytstaticticmat = Convert.ToInt32(100 / (tytfinishedcountmat + tytnotfinishedcountmat) * tytfinishedcountmat);
            ViewBag.tytstaticticmat = tytstaticticmat;
            ViewBag.tytnotfinishedcountmat = tytnotfinishedcountmat;
            ViewBag.tytfinishedcountmat = tytfinishedcountmat;


            decimal tytfinishedcounttar = 0;
            decimal tytnotfinishedcounttar = 0;
            int tytstatictictar = 0;
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
            tytstatictictar = Convert.ToInt32(100 / (tytfinishedcounttar + tytnotfinishedcounttar) * tytfinishedcounttar);
            ViewBag.tytstatictictar = tytstatictictar;
            ViewBag.tytnotfinishedcounttar = tytnotfinishedcounttar;
            ViewBag.tytfinishedcounttar = tytfinishedcounttar;



            decimal tytfinishedcountturk = 0;
            decimal tytnotfinishedcountturk = 0;
            int tytstaticticturk = 0;
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
            tytstaticticturk = Convert.ToInt32(100 / (tytfinishedcountturk + tytnotfinishedcountturk) * tytfinishedcountturk);
            ViewBag.tytstaticticturk = tytstaticticturk;
            ViewBag.tytnotfinishedcountturk = tytnotfinishedcountturk;
            ViewBag.tytfinishedcountturk = tytfinishedcountturk;








            return View();
        }
        public ActionResult AytCourseStatistic()
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

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


            #region ayt
            decimal aytfinishedcountbiyo = 0;
            decimal aytnotfinishedcountbiyo = 0;
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
            aytstaticticbiyo = Convert.ToInt32(100 / (aytfinishedcountbiyo + aytnotfinishedcountbiyo) * aytfinishedcountbiyo);
            ViewBag.aytstaticticbiyo = aytstaticticbiyo;
            ViewBag.aytnotfinishedcountbiyo = aytnotfinishedcountbiyo;
            ViewBag.aytfinishedcountbiyo = aytfinishedcountbiyo;

            decimal aytfinishedcountcog = 0;
            decimal aytnotfinishedcountcog = 0;
            int aytstaticticcog = 0;
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
            aytstaticticcog = Convert.ToInt32(100 / (aytfinishedcountcog + aytnotfinishedcountcog) * aytfinishedcountcog);
            ViewBag.aytstaticticcog = aytstaticticcog;
            ViewBag.aytnotfinishedcountcog = aytnotfinishedcountcog;
            ViewBag.aytfinishedcountcog = aytfinishedcountcog;


            decimal aytfinishedcountdin = 0;
            decimal aytnotfinishedcountdin = 0;
            int aytstaticticdin = 0;
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
            aytstaticticdin = Convert.ToInt32(100 / (aytfinishedcountdin + aytnotfinishedcountdin) * aytfinishedcountdin);
            ViewBag.aytstaticticdin = aytstaticticdin;
            ViewBag.aytnotfinishedcountdin = aytnotfinishedcountdin;
            ViewBag.aytfinishedcountdin = aytfinishedcountdin;


            decimal aytfinishedcountfel = 0;
            decimal aytnotfinishedcountfel = 0;
            int aytstaticticfel = 0;
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
            aytstaticticfel = Convert.ToInt32(100 / (aytfinishedcountfel + aytnotfinishedcountfel) * aytfinishedcountfel);
            ViewBag.aytstaticticfel = aytstaticticfel;
            ViewBag.aytnotfinishedcountfel = aytnotfinishedcountfel;
            ViewBag.aytfinishedcountfel = aytfinishedcountfel;


            decimal aytfinishedcountfiz = 0;
            decimal aytnotfinishedcountfiz = 0;
            int aytstaticticfiz = 0;
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
            aytstaticticfiz = Convert.ToInt32(100 / (aytfinishedcountfiz + aytnotfinishedcountfiz) * aytfinishedcountfiz);
            ViewBag.aytstaticticfiz = aytstaticticfiz;
            ViewBag.aytnotfinishedcountfiz = aytnotfinishedcountfiz;
            ViewBag.aytfinishedcountfiz = aytfinishedcountfiz;


            decimal aytfinishedcountgeo = 0;
            decimal aytnotfinishedcountgeo = 0;
            int aytstaticticgeo = 0;
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

            aytstaticticgeo = Convert.ToInt32(100 / (aytfinishedcountgeo + aytnotfinishedcountgeo) * aytfinishedcountgeo);



            ViewBag.aytstaticticgeo = aytstaticticgeo;
            ViewBag.aytnotfinishedcountgeo = aytnotfinishedcountgeo;
            ViewBag.aytfinishedcountgeo = aytfinishedcountgeo;


            decimal aytfinishedcountkim = 0;
            decimal aytnotfinishedcountkim = 0;
            int aytstatictickim = 0;
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
            aytstatictickim = Convert.ToInt32(100 / (aytfinishedcountkim + aytnotfinishedcountkim) * aytfinishedcountkim);
            ViewBag.aytstatictickim = aytstatictickim;
            ViewBag.aytnotfinishedcountkim = aytnotfinishedcountkim;
            ViewBag.aytfinishedcountkim = aytfinishedcountkim;


            decimal aytfinishedcountmat = 0;
            decimal aytnotfinishedcountmat = 0;
            int aytstaticticmat = 0;
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
            aytstaticticmat = Convert.ToInt32(100 / (aytfinishedcountmat + aytnotfinishedcountmat) * aytfinishedcountmat);
            ViewBag.aytstaticticmat = aytstaticticmat;
            ViewBag.aytnotfinishedcountmat = aytnotfinishedcountmat;
            ViewBag.aytfinishedcountmat = aytfinishedcountmat;


            decimal aytfinishedcounttar = 0;
            decimal aytnotfinishedcounttar = 0;
            int aytstatictictar = 0;
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
            aytstatictictar = Convert.ToInt32(100 / (aytfinishedcounttar + aytnotfinishedcounttar) * aytfinishedcounttar);
            ViewBag.aytstatictictar = aytstatictictar;
            ViewBag.aytnotfinishedcounttar = aytnotfinishedcounttar;
            ViewBag.aytfinishedcounttar = aytfinishedcounttar;



            decimal aytfinishedcountedeb = 0;
            decimal aytnotfinishedcountedeb = 0;
            int aytstaticticedeb = 0;
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
            aytstaticticedeb = Convert.ToInt32(100 / (aytfinishedcountedeb + aytnotfinishedcountedeb) * aytfinishedcountedeb);
            ViewBag.aytstaticticedeb = aytstaticticedeb;
            ViewBag.aytnotfinishedcountedeb = aytnotfinishedcountedeb;
            ViewBag.aytfinishedcountedeb = aytfinishedcountedeb;




            #endregion


            return View();
        }
    }
}