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

        public ActionResult Index(CourseAssignToTeacher courseAssign)
        {
          
            return View(db.CourseAssignToTeachers.ToList());
        }
        public ActionResult CourseAssignToTeacher()
        { 
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
         
            return View();
        }
        [HttpPost]
        public ActionResult CourseAssignToTeacher(CourseAssignToTeacher courseAssign )
        {
            var course = db.Courses.FirstOrDefault(x => x.CourseId==courseAssign.CourseId);
            course.TeacherId = courseAssign.TeacherId;
            db.Entry(course).State = EntityState.Modified;


            courseAssign.Status = "Assigned";
            
                db.Entry(courseAssign).State = EntityState.Added;

                 db.SaveChanges();

                return RedirectToAction("Index", "CourseAssignToTeacher");

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
        public ActionResult CreateCourseStaticsByDeptId()
        {
            ViewBag.DepartmentId =new  SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentCode");
            return View();
        }
       
        public JsonResult GetCourseStaticsByDeptId(int deptId)
        {
            var courseStatics = (from c in db.Courses
                                 join s in db.Semesters on c.SemesterId equals s.SemesterId
                                 join t in db.Teachers on c.TeacherId equals t.TeacherId into result from d in result.DefaultIfEmpty()
                                 select new { c.DepartmentId,TeacherName = d == null ? "Yet Not Assigned" : d.TeacherName,
                                     c.CoursName, c.CourseCode, s.SemesterName })
                                    .Where(c=> c.DepartmentId == deptId).ToList()
                                    .Select(c => new { c.CourseCode, c.CoursName, c.SemesterName, c.TeacherName });

            return Json(courseStatics, JsonRequestBehavior.AllowGet);
        }

    }
}