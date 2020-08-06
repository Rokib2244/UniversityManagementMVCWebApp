using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway=new CourseGateway();
        public List<Course> GetAllCourses()
        {
            return aCourseGateway.GetAllCourses();
        }

        public string AssignCourse(CourseAssign courseAssign)
        {
            var rowAffected = aCourseGateway.AssignCourse(courseAssign);
            if (rowAffected[0] > 0 && rowAffected[1] > 0)
            {
                return "Course Assigned.";
            }
            else
            {
                return "Course Assign failed.";
            }
        }

        public List<Course> GetCoursesByDepartmentId(int id)
        {
            return aCourseGateway.GetCoursesByDepartmentId(id);
        }

        public string UnassignAllCourses()
        {
            List<int> rows = aCourseGateway.UnassignAllCourses();
            rows.Add(aCourseGateway.GetAllCourses().Count);
            if (rows[0] == rows[1] && rows[2] == rows[3])
            {
                return "Course Unassign Successful.";
            }
            else
            {
                return "Course Unassign Failed";
            }
        }

        public List<CourseStatics> GetCourseInformation()
        {
            List<CourseStatics> courseStatics = aCourseGateway.GetCourseInformation();
            List<Teacher> teachers=new TeacherGateway().GetAllTeachers();
            foreach (CourseStatics course in courseStatics)
            {
                foreach (Teacher teacher in teachers)
                {
                    if (course.TeacherID == teacher.ID)
                    {
                        course.TeacherName = teacher.Name;
                        break;
                    }
                    else
                    {
                        course.TeacherName = "Not Assigned Yet";
                    }
                }
            }
            return courseStatics;
        }

        public String SaveCourse(Course aCourse)
        {

            if (aCourseGateway.IsvalidCourse(aCourse) == 0)
            {
                int rowAffected = aCourseGateway.SaveCourse(aCourse);

                if (rowAffected < 1)
                {
                    return "Sorry! Course Saved Failed";
                }
                else
                {
                    return "Saved Successfully!!";
                }
            }
            else
            {
                return "Sorry! Course Saved Failed";
            }

        }

        public StudentCourseAssign GetStudentInfoById(int id)
        {
            return aCourseGateway.GetStudentInfoById(id);
        }

        public List<Course> GetCoursesById(int id)
        {
            return aCourseGateway.GetCoursesById(id);
        }

        public string SaveStudentEnrollment(CourseEnroll courseEnroll)
        {
            if (aCourseGateway.CourseCheck(courseEnroll) == 0)
            {
                int rowAffected = aCourseGateway.SaveStudentEnrollmen(courseEnroll);

                if (rowAffected < 1)
                {
                    return "Sorry! Course Enrollment Failed";
                }
                else
                {
                    return "Saved Successfully!!";
                }
            }
            else
            {
                return "Sorry! Course Enrollment Failed";
            }

        }
    }
}