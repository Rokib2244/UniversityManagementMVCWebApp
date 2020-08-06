using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway aTeacherGateway = new TeacherGateway();

        public List<Teacher> GetAllTeachers()
        {
            return aTeacherGateway.GetAllTeachers();
        }


        //public string SaveTeacher(Teacher aTeacher)
        //{
        //    aTeacher.RemainingCredit = aTeacher.TotalCredit;

        //    int rowAffected = aTeacherGateway.SaveTeacher(aTeacher);

        //    if (rowAffected < 1)
        //    {
        //        return "Error!!";
        //    }
        //    else
        //    {
        //        return "Saved Successfully!!";
        //    }
        //}


        public string Save(Teacher teacher)
        {
            bool hasRows = aTeacherGateway.SearchTeacher(teacher.Email);
            if (!hasRows)
            {
                int rowAffected = aTeacherGateway.SaveTeacher(teacher);
                if (rowAffected > 0)
                {
                    return "Teacher Saved.";
                }
                else
                {
                    return "Teachr Save Failed.";
                }
            }
            else
            {
                return "Teacher with same Email already Exist.";
            }
        }
    }
}