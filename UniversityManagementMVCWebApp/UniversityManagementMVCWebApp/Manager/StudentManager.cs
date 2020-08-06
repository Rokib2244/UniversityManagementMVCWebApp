using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string SaveStudent(Student aStudent)
        {
            aStudent.RegistrationNo = GenarateRegNo(aStudent);
            if (aStudentGateway.IsvalideStudent(aStudent) == 0)
            {
                int rowAffected = aStudentGateway.SaveStudent(aStudent);

                if (rowAffected < 1)
                {
                    return "Sorry! Student Save Failed";
                }
                else
                {
                    return "Saved Successfully!!";
                }
            }
            else
            {
                return "Sorry! Student Save Failed";
            }

        }

        private string GenarateRegNo(Student aStudent)
        {
            var aList = aDepartmentGateway.GetAllDepartment();
            string depName = "";
            foreach (var item in aList)
            {
                if (item.ID == aStudent.DepartmentId)
                {
                    depName = item.Code;
                    break;

                }
            }

            string regNo = depName + "-" + aStudent.Date.Year + "-";
            int num = aStudentGateway.GetStudentNum(regNo) + 1;

            if (num > 99)
            {
                regNo = regNo + num;
            }
            else if (num > 9)
            {
                regNo = regNo + "0" + num;
            }
            else
            {
                regNo = regNo + "00" + num;
            }



            return regNo;
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGateway.GetAllStudents();
        }

        public List<string> GetAllGrades()
        {

            return new List<string>
            {
                "A+","A","A-","B+","B","B-","C+","C","C-","D+","D","D-","F"
            };
        }

        public string SaveStudentResult(CourseEnroll studentResult)
        {

            int rowAffected = aStudentGateway.SaveStudentResult(studentResult);

            if (rowAffected < 1)
            {
                return "Sorry! Student Result Save Failed";
            }
            else
            {
                return "Saved Successfully!!";
            }
        }

        public List<StudentResultView> GetCoursesByStudent(int id)
        {

            return aStudentGateway.GetCoursesByStudent(id);
        }

        public List<StudentCourseWiseResult> GetCoursesResultByStudent(int id)
        {
            return aStudentGateway.GetCoursesResultByStudent(id);
        }
    }
}