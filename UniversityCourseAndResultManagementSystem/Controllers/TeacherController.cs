using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        UniversityManagementEntities db = new UniversityManagementEntities();

        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName");
            ViewBag.Designations = new SelectList(db.Designations.ToList(), "DesignationId", "DesignationName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index", "Teacher");
            }
            ModelState.Clear();
            return View();
        }

        public JsonResult IsEmailExist(string TeacherEmail)
        {
            var email = db.Teachers.ToList();
            if (!email.Any(x => x.TeacherEmail.ToLower() == TeacherEmail.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}