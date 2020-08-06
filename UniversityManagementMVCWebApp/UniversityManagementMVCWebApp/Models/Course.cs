﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please write Course Code")]
        [StringLength(Int32.MaxValue, MinimumLength = 5, ErrorMessage = "Code must be at least 5 character long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please write Course Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please write Course Credit")]
        [Range(.5, 5, ErrorMessage = "Enter valid Credit")]
        public double Credit { get; set; }
        [Required(ErrorMessage = "Please write Course Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select Semester")]
        public int SemesterId { get; set; }
        public string Assigned { get; set; }
        public int? TeacherID { get; set; }


    }
}