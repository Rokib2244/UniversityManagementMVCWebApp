using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Controllers
{

    public class DepartmentController : Controller
    {
        private DepartmentManager aDepartmentManager = new DepartmentManager();

        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                message = aDepartmentManager.SaveDepartment(department);
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ViewDepartments()
        {
            List<Department> departments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departments = departments;
            return View();
        }
    

}
}