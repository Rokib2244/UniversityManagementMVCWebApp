using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class SemesterGateway : ParentGateway
    {
        public List<Semester> GetAllSemester()
        {
            Query = "select * from Semesters";
            Command = new SqlCommand(Query, Connection);
            List<Semester> aSemesters = new List<Semester>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semester aSemester = new Semester
                {
                    Id = Convert.ToInt32(Reader["ID"]),
                    SemesterNo = Convert.ToInt32(Reader["Semester"])
                };

                aSemesters.Add(aSemester);
            }

            Reader.Close();
            Connection.Close();

            return aSemesters;

        }
    }
}