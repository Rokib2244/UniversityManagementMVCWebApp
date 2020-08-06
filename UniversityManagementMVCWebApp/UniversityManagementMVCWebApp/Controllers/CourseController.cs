using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager= new DepartmentManager();
        TeacherManager teacherManager=new TeacherManager();
        SemesterManager aSemesterManager = new SemesterManager();
        StudentManager aStudentManager = new StudentManager();

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            ViewBag.Semester = aSemesterManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course aCourse)
        {

            if (ModelState.IsValid)
            {
                aCourse.Assigned = "False";
                ViewBag.Message = aCourseManager.SaveCourse(aCourse);
            }


            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            ViewBag.Semester = aSemesterManager.GetAllSemester();
            return View();
        }

        public ActionResult Enroll()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(CourseEnroll courseEnroll)
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            if (ModelState.IsValid)
            {
                ViewBag.Message = aCourseManager.SaveStudentEnrollment(courseEnroll);
            }

            return View();
        }


        public ActionResult Assign()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartment();
            departments.Insert(0,new Department()
            {
                ID = 0,Code = "--Select a department--"
            });
            List<Teacher> teachers=new List<Teacher>()
            {
                new Teacher(){ ID = 0,Name = "--Select a teacher--",DepartmentID = 0}
            };
            List<Course> courses=new List<Course>()
            {
                new Course(){ ID = 0,Code = "--Select a course--",DepartmentId = 0}
            };
            //CreateJson();
            ViewBag.Departments = departments;
            ViewBag.Teachers = teachers;
            ViewBag.Courses = courses;
            return View();
        }

        //public void CreateJson()
        //{
            
        //    List<Teacher> teachers = teacherManager.GetAllTeachers();
        //    List<Course> courses = aCourseManager.GetAllCourses();
        //    teachers.Insert(0,new Teacher()
        //    {
        //        ID = 0,
        //        Name = "--Select a teacher--",
        //        DepartmentID = 0
        //    });
        //    courses.Insert(0,new Course()
        //    {
        //        ID = 0,
        //        Code = "--Select a course--",
        //        DepartmentId = 0
        //    });
        //    //open file stream
        //    //using (StreamWriter file =new StreamWriter(Server.MapPath("../Files/teachers.json")))
        //    //{
        //    //    JsonSerializer serializer = new JsonSerializer();
        //    //    //serialize object directly into file stream
        //    //    serializer.Serialize(file,teachers);
        //    //}
        //    //using (StreamWriter file2 = new StreamWriter(Server.MapPath("../Files/courses.json")))
        //    //{
        //    //    JsonSerializer serializer2 = new JsonSerializer();
        //    //    //serialize object directly into file stream
        //    //    serializer2.Serialize(file2, courses);
        //    //}
        //}

        [HttpPost]
        public ActionResult Assign(CourseAssign courseAssign)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message=aCourseManager.AssignCourse(courseAssign);
            }
            
            List<Department> departments = aDepartmentManager.GetAllDepartment();
            departments.Insert(0, new Department()
            {
                ID = 0,
                Code = "--Select a department--"
            });
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher(){ ID = 0,Name = "--Select a teacher--",DepartmentID = 0}
            };
            List<Course> courses = new List<Course>()
            {
                new Course(){ ID = 0,Code = "--Select a course--",DepartmentId = 0}
            };
            //CreateJson();
            ViewBag.Departments = departments;
            ViewBag.Teachers = teachers;
            ViewBag.Courses = courses;
            return View();
        }

        public ActionResult GetTeachersByDepartmentId(int deptId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers();
            var t = teachers.Where(p => p.DepartmentID == deptId);
            return Json(t);
        }

        public ActionResult GetCoursesByDepartmentId(int deptId)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            var c = courses.Where(p => p.DepartmentId == deptId && p.Assigned=="False");
            return Json(c);
        }

        public ActionResult GetTeacherById(int teacherId)
        {
            List<Teacher> teachers = teacherManager.GetAllTeachers();
            var t = teachers.Where(p => p.ID == teacherId);
            return Json(t);
        }
        public ActionResult GetCourseById(int courseId)
        {
            List<Course> courses = aCourseManager.GetAllCourses();
            var c = courses.Where(p => p.ID == courseId);
            return Json(c);
        }

        [HttpGet]
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Unassign")]
        public ActionResult UnassignPost()
        {
            string message = aCourseManager.UnassignAllCourses();
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Statics()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartment();
            departments.Insert(0,new Department
            {
                ID = 0,
                Code = "--Select a Departments--"
            });
            ViewBag.Departments = departments;
            return View();
        }

        public ActionResult GetCourseInformationById(int id)
        {
            List<CourseStatics> courseStatics = aCourseManager.GetCourseInformation();
            var course = courseStatics.Where(a => a.DepartmentID == id);
            return Json(course);
        }


        //Abid
        public ActionResult GetStudentInfoById(int Id)
        {
            StudentCourseAssign assign = aCourseManager.GetStudentInfoById(Id);

            return Json(assign);


        }

        
        public ActionResult GetCoursesById(int Id)
        {
            List<Course> courses = aCourseManager.GetCoursesById(Id);

            return Json(courses);


        }
	}
}