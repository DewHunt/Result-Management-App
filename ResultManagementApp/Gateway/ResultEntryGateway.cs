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
    class ResultEntryGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public ResultEntryGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public List<ResultEntry> GetAllResults()
        {
            query = "SELECT tbl_results.*, tbl_students.name AS student_name, tbl_classes.name AS class_name, tbl_students.roll AS student_roll, tbl_subjects.name AS subject_name FROM tbl_results " +
                "LEFT JOIN tbl_students ON tbl_students.id = tbl_results.student_id " +
                "LEFT JOIN tbl_classes ON tbl_classes.id = tbl_students.class_id " +
                "LEFT JOIN tbl_subjects ON tbl_subjects.id = tbl_results.subject_id " +
                "ORDER BY class_name ASC";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<ResultEntry> allResults = new List<ResultEntry>();

            while (reader.Read())
            {
                ResultEntry aResultEntry = new ResultEntry();

                aResultEntry.Id = Convert.ToInt32(reader["id"]);
                aResultEntry.StudentId = Convert.ToInt32(reader["student_id"]);
                aResultEntry.StudentName = reader["student_name"].ToString();
                aResultEntry.ClassName = reader["class_name"].ToString();
                aResultEntry.Roll = reader["student_roll"].ToString();
                aResultEntry.SubjectName = reader["subject_name"].ToString();
                aResultEntry.Marks = Convert.ToInt32(reader["marks"]);

                allResults.Add(aResultEntry);
            }
            reader.Close();
            connection.Close();

            return allResults;
        }

        public int DeleteResult(int id)
        {
            query = "DELETE FROM tbl_results WHERE id = '" + id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public int SaveResult(ResultEntry aResultEntry)
        {
            query = "INSERT INTO tbl_results (student_id, subject_id, marks) VALUES ('" + aResultEntry.StudentId + "','" + aResultEntry.SubjectId + "','" + aResultEntry.Marks + "')";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public bool IsResultExists(ResultEntry aResultEntry)
        {
            query = "SELECT * FROM tbl_results WHERE subject_id = '" + aResultEntry.SubjectId + "' AND student_id = '" + aResultEntry.StudentId + "' AND id <> '" + aResultEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            reader.Close();
            connection.Close();

            return isExists;
        }

        public int UpdateResult(ResultEntry aResultEntry)
        {
            query = "UPDATE tbl_results SET student_id = '" + aResultEntry.StudentId + "', subject_id = '" + aResultEntry.SubjectId + "', marks = '" + aResultEntry.Marks + "' WHERE id = '" + aResultEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}
