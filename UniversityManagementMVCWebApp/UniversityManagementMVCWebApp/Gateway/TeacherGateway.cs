using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class TeacherGateway:ParentGateway
    {
        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM SaveTeacher";
            Command=new SqlCommand(Query,Connection);
            List<Teacher> teachers=new List<Teacher>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                teachers.Add(new Teacher()
                {
                    ID = Convert.ToInt32(Reader["ID"]),
                    Name = Reader["Name"].ToString(),
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]),
                    TotalCredit = Convert.ToDouble(Reader["TotalCredit"]),
                    RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"])
                });
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }

        public int SaveTeacher(Teacher aTeacher)
        {
            Query =
                "INSERT INTO SaveTeacher VALUES(@Name,@Address,@Email,@ContactNumber,@DesignationID,@DepartmentID,@TotalCredit,@RemainingCredit)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Name", aTeacher.Name);
            Command.Parameters.AddWithValue("Address", aTeacher.Address);
            Command.Parameters.AddWithValue("Email", aTeacher.Email);
            Command.Parameters.AddWithValue("ContactNumber", aTeacher.ContactNumber);
            Command.Parameters.AddWithValue("DesignationID", aTeacher.DesignationID);
            Command.Parameters.AddWithValue("DepartmentID", aTeacher.DepartmentID);
            Command.Parameters.AddWithValue("TotalCredit", aTeacher.TotalCredit);
            Command.Parameters.AddWithValue("RemainingCredit", aTeacher.TotalCredit);

            Connection.Open();


            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }
        public bool SearchTeacher(string email)
        {
            Query = "SELECT * FROM SaveTeacher WHERE Email=@email";
            Command=new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("email", email);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }
    }
}