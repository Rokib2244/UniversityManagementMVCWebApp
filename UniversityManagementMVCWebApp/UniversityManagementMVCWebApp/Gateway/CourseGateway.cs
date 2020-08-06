using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class CourseGateway:ParentGateway
    {
        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM SaveCourse";
            Command=new SqlCommand(Query,Connection);
            List<Course> courses=new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course()
                {
                    Assigned = Reader["Assigned"].ToString(),
                    ID = Convert.ToInt32(Reader["ID"]),
                    Code = Reader["Code"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentID"]),
                    Name = Reader["Name"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"])
                    
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<int> AssignCourse(CourseAssign courseAssign)
        {
            Query = "UPDATE SaveCourse SET Assigned='true',TeacherID="+courseAssign.TeacherID+" WHERE ID=" + courseAssign.CourseID;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInSaveCouseTable = Command.ExecuteNonQuery();
            Connection.Close();
            Query = "UPDATE SaveTeacher SET RemainingCredit=" +
                    (courseAssign.RemainingCredit - courseAssign.CourseCredit) + " WHERE ID=" +
                    courseAssign.TeacherID;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInSaveTeacherTable = Command.ExecuteNonQuery();
            Connection.Close();
            
            return new List<int>()
            {
                rowAffectedInSaveCouseTable,rowAffectedInSaveTeacherTable
            };
        }

        public List<Course> GetCoursesByDepartmentId(int id)
        {
            Query = "SELECT * FROM SaveCourse WHERE DepartmentID=" + id;
            Command = new SqlCommand(Query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course
                {
                    ID=Convert.ToInt32(Reader["ID"]),
                    Code=Reader["Code"].ToString(),
                    Name=Reader["Name"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<int> UnassignAllCourses()
        {
            List<int> idList=new List<int>();
            Query = "SELECT * FROM SaveTeacher";
            Command=new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
               idList.Add(Convert.ToInt32(Reader["ID"]));
            }
            Reader.Close();
            Connection.Close();
            //List<double> totalCreditList=new List<double>();
            int rowAffected=0;
            foreach (int id in idList)
            {
                double totalCredit=0;
                Query = "SELECT TotalCredit FROM SaveTeacher WHERE ID="+id;
                Command=new SqlCommand(Query,Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    totalCredit = Convert.ToDouble(Reader["TotalCredit"]);
                }
                Reader.Close();
                Connection.Close();
                Query = "UPDATE SaveTeacher SET RemainingCredit=" + totalCredit + "WHERE ID=" + id;
                Command=new SqlCommand(Query,Connection);
                Connection.Open();
                int i = Command.ExecuteNonQuery();
                if (i == 1)
                {
                     rowAffected++;
                }
               
                Connection.Close();
            }
            Query = "UPDATE SaveCourse SET Assigned='False',TeacherID=NULL";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedForSaveTeacher = Command.ExecuteNonQuery();
            Connection.Close();
            return new List<int>()
            {
                idList.Count,
                rowAffected,
                rowAffectedForSaveTeacher
            };
            
        }

        public List<CourseStatics> GetCourseInformation()
        {
            Query = "SELECT * FROM ViewCourseStatics";
            Command = new SqlCommand(Query, Connection);
            List<CourseStatics> courses = new List<CourseStatics>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new CourseStatics
                {
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]),
                    Semester = Convert.ToInt32(Reader["Semester"]),
                    Assigned = Reader["Assigned"].ToString(),
                    TeacherID = HandleNullValue(Reader)
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
        private int HandleNullValue(SqlDataReader r)
        {
            if (r["TeacherID"] == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(Reader["TeacherID"]);
            }
        }

        //Abid


        public int SaveCourse(Course aCourse)
        {
            Query =
                "insert into SaveCourse values(@code,@name,@credit,@description,@departmentId,@semesterId,@assigned,@teacher)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", aCourse.Code);
            Command.Parameters.AddWithValue("name", aCourse.Name);
            Command.Parameters.AddWithValue("credit", aCourse.Credit);
            Command.Parameters.AddWithValue("description", aCourse.Description);
            Command.Parameters.AddWithValue("departmentId", aCourse.DepartmentId);
            Command.Parameters.AddWithValue("semesterId", aCourse.SemesterId);
            Command.Parameters.AddWithValue("assigned", aCourse.Assigned);
            Command.Parameters.AddWithValue("teacher", DBNull.Value);

            Connection.Open();


            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;





        }

        public StudentCourseAssign GetStudentInfoById(int id)
        {
            Query = "select * from StudentCourseAssign where ID= @id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("id", id);

            Connection.Open();
            Reader = Command.ExecuteReader();
            StudentCourseAssign assign = null;
            if (Reader.Read())
            {
                assign = new StudentCourseAssign
                {
                    ID = Convert.ToInt32(Reader["ID"]),
                    DepartmentName = Reader["DepartmentName"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Name = Reader["Name"].ToString(),
                    RegistrationNo = Reader["RegistrationNo"].ToString(),
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"])
                };
            }

            return assign;
        }

        public List<Course> GetCoursesById(int id)
        {
            Query = "SELECT * FROM SaveCourse WHERE DepartmentID=" + id;
            Command = new SqlCommand(Query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course
                {
                    Code = Reader["Code"].ToString(),
                    ID = Convert.ToInt32(Reader["ID"])
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public int SaveStudentEnrollmen(CourseEnroll courseEnroll)
        {
            Query =
                "insert into CourseEnroll values(@studentid,@name,@email,@date,@departmentName,@courseId,@courseGrade)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("studentid", courseEnroll.StudentId);
            Command.Parameters.AddWithValue("name", courseEnroll.Name);
            Command.Parameters.AddWithValue("email", courseEnroll.Email);
            Command.Parameters.AddWithValue("date", courseEnroll.Date);
            Command.Parameters.AddWithValue("departmentName", courseEnroll.DepartmentName);
            Command.Parameters.AddWithValue("courseId", courseEnroll.CourseId);
            Command.Parameters.AddWithValue("courseGrade", "Not graded yet");

            Connection.Open();


            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public int CourseCheck(CourseEnroll courseId)
        {
            Query = "select * from CourseEnroll where CourseID = @courseid and StudentID=@id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("courseid", courseId.CourseId);
            Command.Parameters.AddWithValue("id", courseId.StudentId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                Reader.Close();
                Connection.Close();
                return 1;
            }

            Reader.Close();
            Connection.Close();
            return 0;
        }

        public int IsvalidCourse(Course aCourse)
        {
            Query = "select * from SaveCourse where Code = @code or Name=@name";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("code", aCourse.Code);
            Command.Parameters.AddWithValue("name", aCourse.Name);
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                Reader.Close();
                Connection.Close();
                return 1;
            }

            Reader.Close();
            Connection.Close();
            return 0;
        }

        
    }
}