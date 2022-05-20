using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StudentQuizController : Controller
    {
        StudentManager sm = new StudentManager(new EFStudentDal());
        ExamManager em = new ExamManager(new EFExamDal());
        ExamQuestionsManager eqm = new ExamQuestionsManager(new EFExamQuestionsDal());
        ExamQuestionFollowManager eqfm = new ExamQuestionFollowManager(new EFExamQuestionFollowDal());
        StudentExamResultManager serm = new StudentExamResultManager(new EFStudentExamResultDal());
      

        // GET: StudentQuiz
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TytListQuiz()
        {
            return View();
        }


        public ActionResult AytListQuiz()
        {
            return View();
        }

       


         public ActionResult StudentTytExams(int id)
        {
            List<Exam> lst = new List<Exam>();
            switch (id)
            {
                case 1:
                    lst = em.TYTMATKwhereList();

                    break;

                case 2:
                    lst = em.TYTGEOKwhereList();

                    break;
                case 3:
                    lst = em.TYTFİZKwhereList();

                    break;
                case 4:
                    lst = em.TYTKİMwhereList();

                    break;
                case 5:
                    lst = em.TYTBİYOKwhereList();

                    break;
                case 6:
                    lst = em.TYTTURKwhereList();

                    break;
                case 7:
                    lst = em.TYTTARwhereList();

                    break;
                case 8:
                    lst = em.TYTCOGwhereList();

                    break;
                case 9:
                    lst = em.TYTDİNKwhereList();

                    break;
                case 10:
                    lst = em.TYTFELwhereList();

                    break;

            }

            return View(lst);
        }

        public ActionResult StudentAYTExams(int id)
        {

        

            List<Exam> lst = new List<Exam>();
            switch (id)
            {
                case 1:
                    lst = em.AYTMATKwhereList();

                    break;

                case 2:
                    lst = em.AYTGEOKwhereList();

                    break;
                case 3:
                    lst = em.AYTFİZKwhereList();

                    break;
                case 4:
                    lst = em.AYTKİMwhereList();

                    break;
                case 5:
                    lst = em.AYTBİYOKwhereList();

                    break;
                case 6:
                    lst = em.AYTEDEBwhereList();

                    break;
                case 7:
                    lst = em.AYTTARwhereList();

                    break;
                case 8:
                    lst = em.AYTCOGwhereList();

                    break;
                case 9:
                    lst = em.AYTDİNKwhereList();

                    break;
                case 10:
                    lst = em.AYTFELwhereList();

                    break;

            }

            return View(lst);
        }
       static int syc = -1;
         int puan = 0;
        [HttpGet]
        public ActionResult SeedQuiz(int id)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];
                var session = sm.GetBySession(p);
                int studentid = session.StudentID;

                StudentExamResult se = new StudentExamResult();
                StudentExamResult sermlist = new StudentExamResult();
                se.StudentID = studentid;
                se.ExamID = id;
                se.StudentScore = 0;

                
                try
                {
                    sermlist = serm.GetByIdforDelete(se);
                }
                catch 
                {
                    sermlist = null;
                   
                }
               
                if (sermlist != null)
                {
                    sermlist.StudentScore = 0;

                    serm.Update(sermlist);
                }



                if (syc == -1)
                {
                    var deletelist = eqfm.WhereList(id);
                    foreach (var item in deletelist)
                    {
                        eqfm.Delete(item);
                    }
                }

                var questionlist = eqm.GetByIdList(id);
                syc++;


                if (questionlist.Count == 0)
                {

                }
                else
                {
                    if (syc <= 9)
                    {
                        var list = questionlist[syc];
                        ViewBag.correct = list.CorrectAnswer;
                        ViewBag.count = (syc + 1 + ". Soru : ");
                        return View(list);

                    }
                }


                int dgr = questionlist[9].ExamID;
                return RedirectToAction("QuizResult", new { id = dgr });
            }
            catch 
            {
                return RedirectToAction("TytListQuiz");


            }
           

        }

        [HttpPost]
        public ActionResult SeedQuiz(ExamQuestionFollow examQuestionFollow)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];
                var session = sm.GetBySession(p);
                int studentid = session.StudentID;

                examQuestionFollow.StudentID = studentid;
                examQuestionFollow.ExamQuestionFollowDate = DateTime.Parse(DateTime.Now.ToLongTimeString());



                eqfm.Add(examQuestionFollow);

                int dgr = examQuestionFollow.ExamID;



                if (examQuestionFollow.StudentAnswer == examQuestionFollow.CorrectAnswer)
                {
                    puan++;

                }

                return RedirectToAction("SeedQuiz", new { id = dgr });
            }
            catch 
            {
                return RedirectToAction("TytListQuiz");

            }
        
        }

        public ActionResult QuizResult(int id)
        {





            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

            var list = eqfm.WhereList(id);
          

            foreach (var item in list)
            {
                if (item.StudentID == studentid)
                {
                   
                    if (item.StudentAnswer == item.CorrectAnswer)
                    {
                        puan++;
                        
                    }
                }
            
            }
      

            StudentExamResult se = new StudentExamResult();
            se.StudentID = studentid;
            se.ExamID = id;
            se.StudentScore = puan;

            var sermlist = serm.GetByIdforDelete(se);
            if (sermlist != null)
            {
                sermlist.StudentScore = puan;
                sermlist.StudentWrongScore = 10 - (sermlist.StudentScore);
                serm.Update(sermlist);
            }
            else
            {
                se.StudentScore = puan;
                se.StudentWrongScore = 10 - (se.StudentScore);
                serm.Add(se);
            }

            var scoreview = serm.GetByIdforDelete(se);

            ViewBag.wrong = 0;
            ViewBag.truecount = 0;

         

            ViewBag.wrong = 100 - ((scoreview.StudentScore) * 10);
            ViewBag.truecount = (scoreview.StudentScore) * 10;
            


        
            syc = -1;

            return View(se);
        }


        public ActionResult MyQuizResults(int sayfa = 1)
        {
            string p;
            p = (string)Session["StudentEmail"];
            var session = sm.GetBySession(p);
            int studentid = session.StudentID;

            var Resultlist = serm.ListForStudent(studentid);

           
            return View(Resultlist);
        }
    }
}