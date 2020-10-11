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
    class ClassWiseResultGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public ClassWiseResultGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public List<ClassWiseResult> GetAllStudentResultsByClass(int classId)
        {
            query = "SELECT tbl_students.name AS student_name, SUM(tbl_results.marks) AS total_marks FROM tbl_results " +
                "LEFT JOIN tbl_students ON tbl_students.id = tbl_results.student_id " +
                "WHERE tbl_students.class_id = '" + classId + "' " +
                "GROUP BY tbl_results.student_id, tbl_students.name " +
                "ORDER BY student_name ASC";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<ClassWiseResult> allStudentResults = new List<ClassWiseResult>();

            while (reader.Read())
            {
                ClassWiseResult aStudentResultInfo = new ClassWiseResult();

                aStudentResultInfo.StudentName = reader["student_name"].ToString();
                aStudentResultInfo.TotalMarks = Convert.ToInt32(reader["total_marks"]);

                allStudentResults.Add(aStudentResultInfo);
            }

            reader.Close();
            connection.Close();

            return allStudentResults;
        }
    }
}
