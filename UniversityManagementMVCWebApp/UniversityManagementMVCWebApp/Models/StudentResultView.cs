using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class StudentResultView
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
    }
}