using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        UniversityManagementEntities db = new UniversityManagementEntities();
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName");
            ViewBag.Semesters = new SelectList(db.Semesters.ToList(), "SemesterId", "SemesterName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            db.Entry(course).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(db.Departments.ToList(), "DepartmentId", "DepartmentName");
            ViewBag.Semesters = new SelectList(db.Semesters.ToList(), "SemesterId", "SemesterName");
            return View(db.Courses.Where(x => x.CourseId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Course");
        }
        public ActionResult Details(int id)
        {
            return View(db.Courses.Where(x => x.CourseId == id).FirstOrDefault());
        }
        public ActionResult Delete(int id)
        {
            return View(db.Courses.Where(x => x.CourseId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Course course = db.Courses.Where(x => x.CourseId == id).FirstOrDefault();
            db.Entry(course).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index", "Course");
        }
    }
}