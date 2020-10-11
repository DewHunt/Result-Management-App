using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Gateway
{
    class SubjectEntryGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public SubjectEntryGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsSubjectNameExist(SubjectEntry aSubjectEntry)
        {
            query = "SELECT * FROM tbl_subjects WHERE name = '" + aSubjectEntry.Name + "' AND id <> '" + aSubjectEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);

            reader = command.ExecuteReader();

            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();

            return isExist;
        }

        public int SaveSubject(SubjectEntry aSubjectEntry)
        {
            string query = "INSERT INTO tbl_subjects (name, order_by) VALUES ('" + aSubjectEntry.Name + "','" + aSubjectEntry.OrderBy + "')";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<SubjectEntry> GetAllSubjects()
        {
            command = new SqlCommand();
            command.CommandText = "SELECT * FROM tbl_subjects ORDER BY order_by ASC";

            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            List<SubjectEntry> allSubjects = new List<SubjectEntry>();

            while (reader.Read())
            {
                SubjectEntry aSubjectEntry = new SubjectEntry();

                aSubjectEntry.Id = Convert.ToInt32(reader["id"]);
                aSubjectEntry.Name = reader["name"].ToString();
                aSubjectEntry.OrderBy = Convert.ToInt32(reader["order_by"]);

                allSubjects.Add(aSubjectEntry);
            }

            reader.Close();
            connection.Close();

            return allSubjects;
        }

        public int DeleteSubject(int id)
        {
            query = "DELETE FROM tbl_subjects WHERE id = '" + id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public int UpdateSubject(SubjectEntry aSubjectEntry)
        {
            query = "UPDATE tbl_subjects SET name = '" + aSubjectEntry.Name + "', order_by = '" + aSubjectEntry.OrderBy + "' WHERE id = '" + aSubjectEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}
