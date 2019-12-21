using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        UniversityManagementEntities db = new UniversityManagementEntities();
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }
        public ActionResult CreateStudentRegistration()
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentCode");
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudentRegistration(Student student)
        {

            if (ModelState.IsValid)
            {
                var course = db.Departments.FirstOrDefault(x => x.DepartmentId == student.DepartmentId);
                string tempDeptCode = course.DepartmentCode;

                string tempDate = student.Date.Substring(6, 4);
                var lastRecord = (from s in db.Students orderby s.StudentId descending select s).First();

                student.StudentRegNo = tempDeptCode + "-" + tempDate + "-" + (lastRecord.StudentId + 1).ToString();


                db.Entry(student).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            return RedirectToAction("CreateStudentRegistration", "Student");

        }
        public JsonResult IsEmailExist(string studentEmail)
        {
            var email = db.Students.ToList();
            if (!email.Any(x => x.StudentEmail.ToLower() == studentEmail.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}