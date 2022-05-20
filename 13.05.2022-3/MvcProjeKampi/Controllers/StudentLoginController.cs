using BusinessLayer.Conctrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class StudentLoginController : Controller
    {
        StudentLoginManager wlm = new StudentLoginManager(new EFStudentLoginDal());
        StudentManager sm = new StudentManager(new EFStudentDal());
        StudentCourseManager scm = new StudentCourseManager(new EFStudentCourseDal());
        StudentCourseFallowManager scfm = new StudentCourseFallowManager(new EFStudentCourseFallowDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(Student student)
        {

           string newpassword = MD5Olustur(student.StudentPassword);
            student.StudentPassword = newpassword;



            var studentUserInfo = wlm.GetByStudentLogin(student);


            if (studentUserInfo != null)
            {


                FormsAuthentication.SetAuthCookie(studentUserInfo.StudentEmail, false);

                Session["StudentEmail"] = studentUserInfo.StudentEmail;
                return RedirectToAction("Index", "StudentHomepage");


            }
            else
            {
                TempData["AlertMessageStudent"] = "Giriş Yapılamadı :(";
                RedirectToAction("Index");
            }

            return View();
        }

       [HttpGet]
        public ActionResult StudentRegister()
        {
            return View();

        }

        public static string MD5Olustur(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        [HttpPost]
        public ActionResult StudentRegister(Student student)
        {
            var date = DateTime.Parse(DateTime.Now.ToLongTimeString());
            student.MemeberShipDate = date;
            student.StudentStatus = true;
            string newpassword = MD5Olustur(student.StudentPassword);
            student.StudentPassword = newpassword;
        

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/profileımage/" + filename + uzanti;

                if (yol == "~/profileımage/")
                {

                }
                else
                {
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    student.StudentImage = "/profileımage/" + filename + uzanti;
                }

            }

            StudentRegisterValidator registervalidationRules = new StudentRegisterValidator();
            ValidationResult results = registervalidationRules.Validate(student);

            if (results.IsValid)
            {
           

                sm.WAdd(student);
                TempData["AlertMessage"] = "üye Kaydı Oluşturuldu";



                int id = student.StudentID;

                var Mainlist = scm.GetList();

            



                foreach (var item in Mainlist)
                {
                    var ders = item.Ders;
                    var konu = item.Konu;

                    CourseFallow courseFallowdisagne = new CourseFallow();

                    courseFallowdisagne.Konu = konu;
                    courseFallowdisagne.Ders = ders;
                    courseFallowdisagne.Durum = false;
                    courseFallowdisagne.StudentID = id;
                    courseFallowdisagne.Tarih = date;

                    scfm.Add(courseFallowdisagne);

                   
                }

                return View();

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["AlertMessage2"] = "üye Kaydı Oluşturulamadı, Lütfen tüm alanları doldurun";
                }

            }




            return View();



         

        }
    
        public ActionResult StudentHomePage()
        {
            
            
            return View();

        }

        public ActionResult StudentLogout()
        {
            Session["StudentEmail"] = null;

            return RedirectToAction("Index");

        }

    }
}