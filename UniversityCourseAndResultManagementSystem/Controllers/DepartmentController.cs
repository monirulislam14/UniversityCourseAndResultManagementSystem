using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private UniversityManagementEntities db = new UniversityManagementEntities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public ActionResult Details(int id)
        {
            return View(db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault());
        }

        public ActionResult Edit(int id)
        {
            return View(db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Department dept)
        {
            try
            {
                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Department");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Delete(int id)
        {


            return View(db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Department dept = db.Departments.Where(x => x.DepartmentId == id).FirstOrDefault();
            db.Entry(dept).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            db.Entry(dept).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index", "Department");

        }
    }
}