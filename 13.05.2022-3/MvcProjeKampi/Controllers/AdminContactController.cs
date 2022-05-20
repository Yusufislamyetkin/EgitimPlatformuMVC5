using BusinessLayer.Conctrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
       
        public ActionResult Index(int p = 1)
        {
          var List=  cm.ContactList();
          var list2=  List.ToList().ToPagedList(p,4);
            return View(list2);
        }

        public ActionResult GetContactDetail(int id)
        {
           var Cvalues = cm.ContactGetByid(id);
            return View(Cvalues);
        }

        //public ActionResult SeedMessages(int id)
        //{
        //    var List = cm.ContactList();
        //    var list2 = List.ToList().ToPagedList(p, 4);
        //    return View(list2);
        //}
        public ActionResult DeletedMessages(int id)
        {
          var messagesfordelete =  cm.ContactGetByid(id);
            cm.ContactDelete(messagesfordelete);
            TempData["Deleted"] = "Mesaj Silindi";
            return RedirectToAction("/Index/");
           

        }

    }
}