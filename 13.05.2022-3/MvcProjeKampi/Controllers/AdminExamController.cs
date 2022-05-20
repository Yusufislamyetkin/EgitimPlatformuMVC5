using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminExamController : Controller
    {
        ExamManager EM = new ExamManager(new EFExamDal());
        CategoryManager CM = new CategoryManager(new EFCategoryDal());
        ExamQuestionsManager eqm = new ExamQuestionsManager(new EFExamQuestionsDal());

        // GET: AdminExam
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddExam()
        {
            List<SelectListItem> valueExamCat = (from i in CM.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.CategoryName,
                                                     Value = i.CategoryID.ToString()

                                                 }


                                                   ).ToList();

            ViewBag.VE = valueExamCat;
            return View();
        }
        [HttpPost]
        public ActionResult AddExam(Exam exam)
        {
            exam.ExamDate = DateTime.Parse(DateTime.Now.ToLongTimeString());

            EM.AddValue(exam);
            int dgr = exam.ExamID;
            return RedirectToAction("AddQuestion", new { id = dgr });
        }
        public ActionResult ListExam()
        {

            List<Exam> list = EM.GetList();
            return View(list);
        }
        public ActionResult DeleteExam(int id)
        {
            var list = EM.GetByID(id);
            EM.ExamDelete(list);
            return RedirectToAction("ListExam");
        }

        static int syc = -1;

        [HttpGet]
        public ActionResult AddQuestion(int id)
        {
            ViewBag.soru = syc + 2;
            ExamQuestion ex = new ExamQuestion();
            ex.ExamID = id;
            return View(ex);
        }

       static List<ExamQuestion> eq1 = new List<ExamQuestion>();
        [HttpPost]
        public ActionResult AddQuestion(ExamQuestion ExamQuestion)
        {
        

            try
            {

                Random rnd = new Random();
                int rndnumber = rnd.Next(0, 9999);
                if (ExamQuestion.CorrectAnswer != null)
                {
                    ExamQuestion.CorrectAnswer = ExamQuestion.CorrectAnswer.ToUpper();
                }

                if (Request.Files.Count > 0)
                {
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);

                    string yol = "~/ımage/" + filename;

                    if (yol == "~/ımage/")
                    {
                       
                    }
                    else
                    {
                        yol = "~/ımage/" + filename + rndnumber.ToString() + uzanti;
                        Request.Files[0].SaveAs(Server.MapPath(yol));
                        ExamQuestion.QuestionImage = "/ımage/" + filename + rndnumber.ToString() + uzanti;
                    }

                }


                eq1.Add(ExamQuestion);

                int id = ExamQuestion.ExamID;
                syc++;
                if (syc < 9)
                {
                    return RedirectToAction("AddQuestion", new { id = id });
                }

                if (syc == 9)
                {
                    foreach (var item in eq1.ToList())
                    {
                        eqm.Add(item);
                     
                       
                    }

                    syc = -1;
                    eq1.Clear();
                    TempData["AlertMessage1"] = "Sorular Eklendi";
                    return RedirectToAction("ListExam");

                }

                return RedirectToAction("ListExam");
            }
            catch
            {
                return RedirectToAction("ListExam");

            }






        }
        //public ActionResult ListQuestion(int id)
        //{
        //    //List<Questions> list = QM.WhereList(id);
        //    //return View(list);
        //}

        public ActionResult SeedQues(int id)
        {
            var listques = eqm.GetByIdList(id);
            return View(listques);

        }

    }
}