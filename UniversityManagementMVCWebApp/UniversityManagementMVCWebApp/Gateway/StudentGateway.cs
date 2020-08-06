using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class StudentGateway : ParentGateway
    {
        public int SaveStudent(Student aStudent)
        {
            Query = "insert into SaveStudent values(@name,@email,@contact,@date,@address,@regNo,@department)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aStudent.Name);
            Command.Parameters.AddWithValue("email", aStudent.Email);
            Command.Parameters.AddWithValue("contact", aStudent.ContactNo);
            Command.Parameters.AddWithValue("date", aStudent.Date);
            Command.Parameters.AddWithValue("address", aStudent.Address);
            Command.Parameters.AddWithValue("regNo", aStudent.RegistrationNo);
            Command.Parameters.AddWithValue("department", aStudent.DepartmentId);

            Connection.Open();


            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetStudentNum(string regNo)
        {
            Query = "select * from SaveStudent where RegistrationNo like '" + regNo + "%" + "'";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();
            Reader = Command.ExecuteReader();

            int rowAffected = 0;
            while (Reader.Read())
            {
                rowAffected++;
            }
            Reader.Close();
            Connection.Close();
            return rowAffected;
        }

        public List<Student> GetAllStudents()
        {
            Query = "select * from SaveStudent";

            Command = new SqlCommand(Query, Connection);

            List<Student> students = new List<Student>();

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                Student aStudent = new Student
                {
                    Id = Convert.ToInt32(Reader["ID"]),
                    Name = Reader["Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Date = Convert.ToDateTime(Reader["Date"]),
                    Address = Reader["Address"].ToString(),
                    RegistrationNo = Reader["RegistrationNo"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentId"])

                };

                students.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public int SaveStudentResult(CourseEnroll studentResult)
        {

            //Query =
            //    "insert into StudentResult values(@studentid,@name,@email,@departmentName,@courseId,@courseGrade)";

            Query = "update CourseEnroll set CourseGrade = @grade where StudentID=@id AND CourseID=@courseID";
            Command = new SqlCommand(Query, Connection);

            //Command.Parameters.Clear();
            //Command.Parameters.AddWithValue("studentid", studentResult.StudentID);
            //Command.Parameters.AddWithValue("name", studentResult.Name);
            //Command.Parameters.AddWithValue("email", studentResult.Email);
            //Command.Parameters.AddWithValue("departmentName", studentResult.DepartmentName);
            Command.Parameters.AddWithValue("courseId", studentResult.CourseId);
            Command.Parameters.AddWithValue("grade", studentResult.CourseGrade);
            Command.Parameters.AddWithValue("id", studentResult.StudentId);

            Connection.Open();


            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public List<StudentResultView> GetCoursesByStudent(int id)
        {

            Query = "SELECT * FROM StudentResultView WHERE StudentID= @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("id", id);
            List<StudentResultView> courses = new List<StudentResultView>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new StudentResultView
                {
                    CourseName = Reader["CourseName"].ToString(),
                    CourseID = Convert.ToInt32(Reader["CourseID"])
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;

        }

        public List<StudentCourseWiseResult> GetCoursesResultByStudent(int id)
        {


            Query = "select * from StudentCourseWiseView where StudentID= @id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", id);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentCourseWiseResult> result = new List<StudentCourseWiseResult>();
            while (Reader.Read())
            {

                StudentCourseWiseResult aResult = new StudentCourseWiseResult
                {

                    StudentID = Convert.ToInt32(Reader["StudentID"]),

                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),

                    CourseGrade = Reader["CourseGrade"].ToString()
                };

                result.Add(aResult);
            }
            Reader.Close();
            Connection.Close();

            return result;

        }

        public int IsvalideStudent(Student aStudent)
        {

            Query = "select * from SaveStudent where Email=@email or ContactNo=@contactNo";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("Email", aStudent.Email);
            Command.Parameters.AddWithValue("ContactNo", aStudent.ContactNo);
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