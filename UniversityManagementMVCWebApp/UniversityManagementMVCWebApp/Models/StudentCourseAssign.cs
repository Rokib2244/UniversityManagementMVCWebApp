using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class StudentCourseAssign
    {
        public int ID { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentID { get; set; }
    }
}