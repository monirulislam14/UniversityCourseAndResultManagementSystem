using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        private UniversityManagementEntities db = new UniversityManagementEntities();
        public ActionResult CourseAssignToTeacher()
        { 
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.Teachers = new SelectList(db.Departments, "TeacherId", "TeacherName");
            ViewBag.Courses = new SelectList(db.Departments, "CourseId", "CourseCode");

            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(CourseAssignToTeacher courseAssign)
        {

            if (ModelState.IsValid)
            {
                db.Entry(courseAssign).State = EntityState.Added;
                db.SaveChanges();
                return View();
            }

            return View();
       
        }
        public JsonResult GetTeacherByDeptId(int departmentId)
        {
            var teachers = db.Teachers.Where(x => x.DepartmentId == departmentId).ToList();
            return Json(teachers);
        }

        public JsonResult GetCourseByDeptId(int departmentId)
        {
            var courses = db.Courses.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(courses);
        }
        public JsonResult GetCreditToBeTakenById(int teacherId)
        {
            var teacher = db.Teachers.FirstOrDefault(x => x.TeacherId == teacherId);

            return Json(teacher);
        }
        public JsonResult GetCourseCodeById(int courseId)
        {
            var course = db.Courses.FirstOrDefault(x => x.CourseId == courseId);

            return Json(course);
        }

      

    }
}