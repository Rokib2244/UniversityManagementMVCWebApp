using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Write Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Write Student Email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Write Student Contact Number")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Write Student Address")]
        public string Address { get; set; }
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage = "Please Select Student Separtment")]
        public int DepartmentId { get; set; }
    }
}