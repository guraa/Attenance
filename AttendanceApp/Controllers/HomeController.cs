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
        AttendanceContext db = new AttendanceContext();
        public ActionResult Index(Teachers objUser)
        {

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InitClass(string TeacherId)
        {
            if (Convert.ToInt32(TeacherId) > 0)
            {

                using (AttendanceContext db = new AttendanceContext())
                {
                    String uniqueCode = DateTime.Now.Ticks.ToString("x");
                    db.Init.Add(new Init()
                    {
                        Code = uniqueCode,
                        Status = "Started",
                        TeacherId = Convert.ToInt32(TeacherId)


                    });
                    db.SaveChanges();
                    var teacherToInt = int.Parse(TeacherId);
                    var obj = db.Init.Where(a => a.TeacherId.Equals(teacherToInt) && a.Status.Equals("Started")).FirstOrDefault();
                    var teacher = db.Teachers.Where(a => a.Id.Equals(teacherToInt)).FirstOrDefault();

                    var createStarted = new StartedClasses
                    {
                        InitId = obj.Id,
                        Code = obj.Code,
                        TeacherId = obj.TeacherId,
                        TeacherName = teacher.FirstName

                    };


                    return View(createStarted);

                }
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(string InitId, String Change)
        {
            using (AttendanceContext db = new AttendanceContext())
            {


                var InitIdToInt = int.Parse(InitId);
                var status = (from i in db.Init
                              where i.Id == InitIdToInt
                              select i).FirstOrDefault();

                if (Change == "Delete")
                {
                    db.Init.Remove(status);
                }
                else if (Change == "End")
                {
                    status.Status = "Ended";
                }
                db.SaveChanges();
                return View("Index");

            }
        }


    }

}

