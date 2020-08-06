using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class DesignationGateway : ParentGateway
    {
        public List<Designation> GetAllDesignation()
        {
            Query = "SELECT * FROM Designation";
            Command = new SqlCommand(Query, Connection);
            List<Designation> designations = new List<Designation>();
            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Designation designation = new Designation
                {
                    Id = Convert.ToInt32(Reader["ID"]),
                    DesignationOfTeacher = Reader["Designation"].ToString()
                };

                designations.Add(designation);
            }

            Reader.Close();
            Connection.Close();

            return designations;
        }
    }
}