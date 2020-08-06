using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        TeacherManager aTeacherManager = new TeacherManager();
        DesignationManager aDesignationManager = new DesignationManager();

        //[HttpGet]
        //public ActionResult Save()
        //{
        //    ViewBag.Departments = aDepartmentManager.GetAllDepartment();
        //    ViewBag.Designations = aDesignationManager.GetAllDesignation();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Save(Teacher aTeacher)
        //{
        //    ViewBag.Message = aTeacherManager.SaveTeacher(aTeacher);

        //    ViewBag.Departments = aDepartmentManager.GetAllDepartment();
        //    ViewBag.Designations = aDesignationManager.GetAllDesignation();
        //    return View();
        //}
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            ViewBag.Designations = aDesignationManager.GetAllDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aTeacherManager.Save(teacher);
            }
            ViewBag.Message = message;
            ViewBag.Departments = aDepartmentManager.GetAllDepartment();
            ViewBag.Designations = aDesignationManager.GetAllDesignation();
            return View();
        }
	}
}