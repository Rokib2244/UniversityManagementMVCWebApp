using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class StudentResult
    {
        public int ID { get; set; }
        public int StudentID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int CourseID { get; set; }

        //public string CourseCode { get; set; }
        //public string CourseName { get; set; }
        //[RegularExpression("[0-9]",ErrorMessage = "Select a Grade")]
        public string CourseGrade { get; set; }
    }
}