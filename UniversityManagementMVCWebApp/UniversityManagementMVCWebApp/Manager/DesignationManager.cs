using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway = new DesignationGateway();
        public List<Designation> GetAllDesignation()
        {
            return aDesignationGateway.GetAllDesignation();
        }
    }
}