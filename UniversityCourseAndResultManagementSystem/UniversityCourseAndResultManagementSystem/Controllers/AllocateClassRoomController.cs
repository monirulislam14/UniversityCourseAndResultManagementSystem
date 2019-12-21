using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagementSystem.Gateway;
using UniversityCourseAndResultManagementSystem.Models;

namespace UniversityCourseAndResultManagementSystem.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        UniversityManagementEntities db = new UniversityManagementEntities();
        public ActionResult Index(CourseAssignToTeacher courseAssign)
        {

            return View(db.CourseAssignToTeachers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

            ViewBag.Courses = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.Rooms = new SelectList(db.Rooms, "RoomId", "RoomNo");
            ViewBag.SevenDayWeeks = new SelectList(db.SevenDayWeeks, "DayId", "DayCode");


            return View();
        }
        [HttpPost]
        public ActionResult Create(ClassRoomAllocation classRoomAllocation)
        {
            classRoomAllocation.Status = "Allocate";
            classRoomAllocation.TimeFrom = classRoomAllocation.TimeFrom.Remove(2, 1);
            classRoomAllocation.TimeTo = classRoomAllocation.TimeTo.Remove(2, 1);


            db.Entry(classRoomAllocation).State = EntityState.Added;
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Create", "AllocateClassRoom");

        }

        public ActionResult ViewClassScheduleAndRoomAllocation()
        {
            ViewBag.Departments = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");

            return View();
        }


        public JsonResult GetClassScheduleAndRoomAllocationByDeptId(int deptId)
        {
            var getAllClassScheduleViews = GetAllClassScheduleViews(deptId);
            return Json(getAllClassScheduleViews);
        }

        public List<ClassScheduleView> GetAllClassScheduleViews(int departmentId)
        {
            ViewClassSchedule gateway = new ViewClassSchedule();
            List<ClassScheduleView> list = gateway.GetAllClassScheduleViewsByDeptId(departmentId);
            List<ClassScheduleView> myList = new List<ClassScheduleView>();

            for (var i = 0; i < list.Count;)
            {
                ClassScheduleView classView = list[i];
                ClassScheduleView temp = new ClassScheduleView();
                temp.CourseCode = classView.CourseCode;
                temp.CourseName = classView.CourseName;
                temp.ScheduleInfo = ("R. No : " + classView.RoomName + ", " + classView.DayShortName + ", " + classView.TimeFrom + " - " + classView.TimeTo) + "</br>";
                int ck = 0;
                i++;

                for (var j = i; j < list.Count; j++)
                {
                    ck = 1;
                    ClassScheduleView classView2 = list[j - 1];
                    ClassScheduleView classView3 = list[j];

                    if (classView2.CourseCode == classView3.CourseCode)
                    {
                        i++;
                        temp.ScheduleInfo += ("R. No : " + classView3.RoomName + ", " + classView3.DayShortName + ", " +
                                                         classView3.TimeFrom + " - " + classView3.TimeTo + "</br>");

                        //myList.Add(temp);
                    }
                    else
                    {
                        if (classView.RoomName == "")
                        {
                            temp.ScheduleInfo = "Not Assigned Yet";
                        }
                        myList.Add(temp);
                        break;
                    }
                }
                if (ck == 0)
                {
                    if (classView.RoomName == "")
                    {
                        temp.ScheduleInfo = "Not Assigned Yet";
                    }
                    myList.Add(temp);
                }

            }
            return myList;

        }
    }
}