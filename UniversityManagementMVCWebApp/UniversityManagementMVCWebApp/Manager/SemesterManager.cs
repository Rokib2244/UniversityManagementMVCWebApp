using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();
        public List<Semester> GetAllSemester()
        {
            return aSemesterGateway.GetAllSemester();
        }
    }
}