using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class StudentCourseWiseResult
    {
        public int StudentID { get; set; }
        public string CourseGrade { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}