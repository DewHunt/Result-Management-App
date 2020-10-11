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
    class StudentEntryGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public StudentEntryGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsStudentExists(StudentEntry aStudentEntry)
        {
            query = "SELECT * FROM tbl_students WHERE class_id = '" + aStudentEntry.ClassId + "' AND roll = '" + aStudentEntry.Roll + "' AND id <> '" + aStudentEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            reader.Close();
            connection.Close();

            return isExists;
        }

        public StudentEntry GetStudentInfoById(int studentId)
        {
            query = "SELECT tbl_students.*, tbl_classes.name AS class_name FROM tbl_students " +
                "LEFT JOIN tbl_classes ON tbl_classes.id = tbl_students.class_id " +
                "WHERE tbl_students.id = '" + studentId + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            
            StudentEntry studentInfo = new StudentEntry();

            while (reader.Read())
            {
                studentInfo.Id = Convert.ToInt32(reader["Id"]);
                studentInfo.Name = reader["name"].ToString();
                studentInfo.Phone = reader["phone"].ToString();
                studentInfo.Roll = reader["roll"].ToString();
                studentInfo.ClassName = reader["class_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return studentInfo;
        }

        public List<StudentEntry> GetAllStudentsByClass(int classId)
        {
            query = "SELECT * FROM tbl_students WHERE class_id = '" + classId + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<StudentEntry> allStudents = new List<StudentEntry>();

            while (reader.Read())
            {
                StudentEntry aStudentEntry = new StudentEntry();

                aStudentEntry.Id = Convert.ToInt32(reader["id"]);
                aStudentEntry.ClassId = Convert.ToInt32(reader["class_id"]);
                aStudentEntry.Roll = reader["roll"].ToString();
                aStudentEntry.Name = reader["name"].ToString();
                aStudentEntry.Phone = reader["phone"].ToString();
                aStudentEntry.OrderBy = Convert.ToInt32(reader["order_by"]);

                allStudents.Add(aStudentEntry);
            }
            reader.Close();
            connection.Close();

            return allStudents;
        }

        public int SaveStudent(StudentEntry aStudentEntry)
        {
            query = "INSERT INTO tbl_students (class_id, roll, name, phone, order_by) VALUES ('" + aStudentEntry.ClassId + "','" + aStudentEntry.Roll + "','" + aStudentEntry.Name + "','" + aStudentEntry.Phone + "','" + aStudentEntry.OrderBy + "')";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<StudentEntry> GetAllStudents()
        {
            query = "SELECT tbl_students.*, tbl_classes.name AS class_name FROM tbl_students" +
                " LEFT JOIN tbl_classes ON tbl_classes.id = tbl_students.class_id" +
                " ORDER BY class_name ASC";

            connection.Open();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();

            List<StudentEntry> allStudents = new List<StudentEntry>();

            while (reader.Read())
            {
                StudentEntry aStudentEntry = new StudentEntry();

                aStudentEntry.Id = Convert.ToInt32(reader["id"]);
                aStudentEntry.ClassId = Convert.ToInt32(reader["class_id"]);
                aStudentEntry.Roll = reader["roll"].ToString();
                aStudentEntry.Name = reader["name"].ToString();
                aStudentEntry.Phone = reader["phone"].ToString();
                aStudentEntry.OrderBy = Convert.ToInt32(reader["order_by"]);
                aStudentEntry.ClassName = reader["class_name"].ToString();

                allStudents.Add(aStudentEntry);
            }
            reader.Close();
            connection.Close();

            return allStudents;
        }

        public int DeleteStudent(int id)
        {
            query = "DELETE FROM tbl_students WHERE id = '" + id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public int UpdatedStudent(StudentEntry aStudentEntry)
        {
            query = "UPDATE tbl_students SET class_id = '" + aStudentEntry.ClassId + "', roll = '" + aStudentEntry.Roll + "', name = '" + aStudentEntry.Name + "', phone = '" + aStudentEntry.Phone + "', order_by = '" + aStudentEntry.OrderBy + "' WHERE id = '" + aStudentEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}
