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
    class ClassGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ResultManagementSystemDBString"].ConnectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;

        public ClassGateway()
        {
            connection = new SqlConnection(connectionString);
        }

        public bool IsClassNameExist(ClassEntry aClassEntry)
        {
            query = "SELECT * FROM tbl_classes WHERE name = '" + aClassEntry.Name + "' AND id <> '" + aClassEntry.Id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);

            reader = command.ExecuteReader();

            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();

            return isExist;
        }

        public int SaveClass(ClassEntry aClassEntry)
        {
            string query = "INSERT INTO tbl_classes (name, order_by) VALUES ('"+aClassEntry.Name+"','"+aClassEntry.OrderBy+"')";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public int UpdateClass(ClassEntry aClassEntry)
        {
            query = "UPDATE tbl_classes SET name = '"+aClassEntry.Name+"', order_by = '"+aClassEntry.OrderBy+"' WHERE id = '"+aClassEntry.Id+"'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public int DeleteClass(int id)
        {
            query = "DELETE FROM tbl_classes WHERE id = '" + id + "'";

            connection.Open();
            command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }

        public List<ClassEntry> GetAllClasses()
        {
            command = new SqlCommand();
            command.CommandText = "SELECT * FROM tbl_classes ORDER BY order_by ASC";

            command.Connection = connection;
            command.Connection.Open();

            reader = command.ExecuteReader();

            List<ClassEntry> allClasses = new List<ClassEntry>();

            while(reader.Read())
            {
                ClassEntry aClassEntry = new ClassEntry();

                aClassEntry.Id = Convert.ToInt32(reader["id"]);
                aClassEntry.Name = reader["name"].ToString();
                aClassEntry.OrderBy = Convert.ToInt32(reader["order_by"]);

                allClasses.Add(aClassEntry);
            }

            reader.Close();
            connection.Close();

            return allClasses;
        }
    }
}
