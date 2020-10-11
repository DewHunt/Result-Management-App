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
    class IndividualResultGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public IndividualResultGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public float GetResultAverage(int studentId)
        {
            query = "SELECT marks FROM tbl_results WHERE student_id = '" + studentId + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            int totalMarks = 0;
            float cgpa = 0;

            while (reader.Read())
            {
                totalMarks += Convert.ToInt32(reader["marks"]);
            }
            reader.Close();
            connection.Close();

            cgpa = (float)totalMarks / 3;

            return cgpa;
        }

        public List<IndividualResult> GetAllSubjectResults(int studenId)
        {
            query = "SELECT tbl_subjects.name AS subject_name, tbl_results.marks AS marks FROM tbl_results " +
                "LEFT JOIN tbl_subjects ON tbl_subjects.id = tbl_results.subject_id " +
                "WHERE tbl_results.student_id = '" + studenId + "' " +
                "ORDER BY subject_name ASC";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<IndividualResult> allSubjectResultInfo = new List<IndividualResult>();

            while (reader.Read())
            {
                IndividualResult subjectResultInfo = new IndividualResult();

                subjectResultInfo.SubjectName = reader["subject_name"].ToString();
                subjectResultInfo.Marks = Convert.ToInt32(reader["marks"]);

                allSubjectResultInfo.Add(subjectResultInfo);
            }
            reader.Close();
            connection.Close();

            return allSubjectResultInfo;
        }
    }
}
