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
    public class ContactMeController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        // GET: ContactMe
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.MessageDateT = DateTime.Parse(DateTime.Now.ToLongTimeString());


            ContactValidator contactValidator = new ContactValidator();
            ValidationResult results = contactValidator.Validate(contact);

            if (results.IsValid)
            {
                TempData["AlertMessage1"] = "Mesaj Gönderildi :)";
                cm.ContactAdd(contact);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["AlertMessage2"] = "Mesaj Gönderilemedi :(";

                }

            }

            return View();
        }

    }
}