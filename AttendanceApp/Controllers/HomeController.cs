using AttendanceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.SearchModels;
using System.Dynamic;

namespace AttendanceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Teachers objUser)
        {
            AttendanceContext db = new AttendanceContext();
            var teacher = db.Teachers.ToList();
            var classes = db.Classes.ToList();
            ViewBag.Title = "AttendanceApp";
            ViewBag.User = Session["UserID"];
            ViewBag.UserName = Session["UserName"];

            var teacherClasses = (from c in classes
                                 join t in teacher on c.TeacherId equals t.Id
     
                                  select new Classes4Teacher
                                  {
                                       ClassId = c.Id,
                                       ClassName = c.ClassName,
                                       Id = t.Id
                                  }).ToList();
           
            return View(teacherClasses);
        }
        


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Teachers objUser)
        {
            if (ModelState.IsValid)
            {
                using (AttendanceContext db = new AttendanceContext())
                {
                    var obj = db.Teachers.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUser);
        }

      

    }
}
