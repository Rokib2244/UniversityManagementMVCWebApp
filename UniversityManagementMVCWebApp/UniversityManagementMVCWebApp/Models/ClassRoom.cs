﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class ClassRoom
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
    }
}