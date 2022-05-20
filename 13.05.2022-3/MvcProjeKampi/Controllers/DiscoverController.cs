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
    public class DiscoverController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager catm = new CategoryManager(new EFCategoryDal());
        ContentManager com = new ContentManager(new EFContentDal());
        StudentManager vm = new StudentManager(new EFStudentDal());

        [HttpGet]
        public ActionResult Index()
        {
            var values = hm.ShowList();
           
            return View(values);
           
        }
     

        [HttpPost]
        public ActionResult Index(Content content)
        {
            string p;
            p = (string)Session["StudentEmail"];

            var StudentValue = vm.GetBySession(p);
       
            content.StudentID = StudentValue.StudentID;
            content.ContentDate = DateTime.Parse(DateTime.Now.ToLongTimeString());
        
            com.ContentAdd(content);

            return View("SendedPopup");


            
        }

        public ActionResult SendedPopup()
        {

            return View();
        }

        [HttpGet]
        public ActionResult TimeLine()
        {
            var values = com.GetList();
           

            return View(values);
        }


        [HttpGet]
       public ActionResult interactionArea(int id)
        {
            var values = hm.GetByID(id);
            ViewBag.content = com.GetWhereList(id);
                         

            return View(values);

        }
        //[HttpPost]
        //public ActionResult interactionArea(int id)
        //{

        //}

        public ActionResult CategorySelect()
        {

            var values = catm.GetList();


            return View(values);
        }
        
        public ActionResult CategorySelectList(int id)
        {

            var values = hm.WhereListCategory(id);
            ViewBag.categoryname = catm.GetByID(id).CategoryName;
          
            


            return View(values);
        }

        public ActionResult CountryModal()
        {
            var values = hm.ShowList();


            return View(values);
        }

    }
}