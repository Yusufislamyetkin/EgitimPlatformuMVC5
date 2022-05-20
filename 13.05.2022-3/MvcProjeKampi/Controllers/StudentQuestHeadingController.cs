using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StudentQuestHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        StudentCourseManager scm = new StudentCourseManager(new EFStudentCourseDal());
        StudentManager sm = new StudentManager(new EFStudentDal());
        ContentManager contm = new ContentManager(new EFContentDal());

        // GET: StudentQuestHeading
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult QuestionHeading()
        {

            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()

                                                  }


                                                    ).ToList();

            ViewBag.VC = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult QuestionHeading(Heading heading)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];

                var StudentValue = sm.GetBySession(p);

                int sid = StudentValue.StudentID;

                if (Request.Files.Count > 0)
                {
                    string filename = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/ımage/" + filename + uzanti;

                    if (yol == "~/ımage/")
                    {

                    }
                    else
                    {
                        Request.Files[0].SaveAs(Server.MapPath(yol));
                        heading.Headingimage = "/ımage/" + filename + uzanti;
                    }

                }


                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
                heading.HeadingStatus = true;
                heading.StudentID = sid;
                int dgr = sid;



                QuestionHeadingValidator headingvalid = new QuestionHeadingValidator();
                ValidationResult results = headingvalid.Validate(heading);

                if (results.IsValid)
                {
                    hm.HeadingAdd(heading);
                    return RedirectToAction("MyQuestion", new { id = dgr });
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                              select new SelectListItem
                                                              {
                                                                  Text = i.CategoryName,
                                                                  Value = i.CategoryID.ToString()

                                                              }


                                                     ).ToList();

                        ViewBag.VC = valueCategory;
                    }

                }



                return View();
            }
            catch
            {

                return View();
               
            }
           

         
           
        }

        public ActionResult MyQuestion()
        {
            string p;
            p = (string)Session["StudentEmail"];

          

         
            var list = hm.WhereListStatus(p);
            list.Reverse();
            return View(list);
        }

        public ActionResult MyQuestionDelete(int id)
        {

           var deletevalue = hm.GetByID(id);
            hm.HeadingDelete(deletevalue);

            return RedirectToAction("MyQuestion");
        }
        [HttpGet]
        public ActionResult MyQuestionUpdate(int id)
        {
            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()

                                                  }


                                               ).ToList();

       

            ViewBag.VC = valueCategory;
            var updatevalue = hm.GetByID(id);


            return View(updatevalue);
        }
        [HttpPost]
        public ActionResult MyQuestionUpdate(Heading heading)
        {
            try
            {
                string p;
                p = (string)Session["StudentEmail"];

                var StudentValue = sm.GetBySession(p);

                int sid = StudentValue.StudentID;

                heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
                heading.HeadingStatus = true;
                heading.StudentID = sid;
                hm.HeadingUpdate(heading);
                return RedirectToAction("MyQuestion");
            }
            catch 
            {
                return RedirectToAction("MyQuestion");

            }
           


         
        }

        [HttpGet]
        public ActionResult AllQuestionHeading()
        {
            

            List<SelectListItem> valueCategory = (from i in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.CategoryName,
                                                      Value = i.CategoryID.ToString()

                                                  }


                                                    ).ToList();



            ViewBag.VC = valueCategory;

            var list = hm.WhereListActiveAll();
            list.Reverse();
          



            ViewBag.head = cm.GetList();

            return View(list);

        }
        [HttpPost]
        public ActionResult AllQuestionHeading(Heading heading)
        {




            return RedirectToAction("MyQuestion");
        }

        public ActionResult CategoryToList(int id)
        {
            ViewBag.head = cm.GetList();
           var list = hm.WhereListCat(id);
            list.Reverse();
            return View(list);
        }

        public ActionResult interactionArena(Content content)
        {


            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/ımage/" + filename + uzanti;

                if (yol == "~/ımage/")
                {

                }
                else
                {
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    content.AnswerImage = "/ımage/" + filename + uzanti;
                }

            }


            int dgr = 0;
            string p;
            p = (string)Session["StudentEmail"];
            var StudentValue = sm.GetBySession(p);
            content.StudentID = StudentValue.StudentID;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            contm.ContentAdd(content);

            dgr= content.HeadingID; 
           
            
            return RedirectToAction("ContentArena", new { id = dgr });
        }

        [HttpGet]
        public ActionResult ContentArena(int id)
        {
            ViewBag.head = cm.GetList();
            var questionHeading = hm.GetByID(id);
            ViewBag.content = contm.GetWhereList(id);

            return View(questionHeading);
        }


        [HttpPost]
        public ActionResult ContentArena(Content content)
        {
            string p;
            p = (string)Session["StudentEmail"];
            var StudentValue = sm.GetBySession(p);
            content.StudentID = StudentValue.StudentID;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
            contm.ContentAdd(content);


            return RedirectToAction("AllQuestionHeading");
        }

        public ActionResult MyQuestionHeading()
        {

            return View();
        }

    }
}