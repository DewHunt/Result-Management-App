using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class StudentEntryManager
    {
        private StudentEntryGateway aStudentEntryGateway = new StudentEntryGateway();
        private ClassGateway aClassGateway = new ClassGateway();

        public List<ClassEntry> GetAllClasses()
        {
            return aClassGateway.GetAllClasses();
        }

        public string SaveStudent(StudentEntry aStudentEntry)
        {
            if (aStudentEntryGateway.IsStudentExists(aStudentEntry))
            {
                return "This Student Already Exists";
            }
            else
            {
                int rowAffected = aStudentEntryGateway.SaveStudent(aStudentEntry);

                if (rowAffected > 0)
                {
                    return "Student Saved Successfully";
                }
                return "Saved Failed";
            }
        }

        public string UpdateStudent(StudentEntry aStudentEntry)
        {
            if (aStudentEntryGateway.IsStudentExists(aStudentEntry))
            {
                return "This Student Already Exists";
            }
            else
            {
                int rowAffected = aStudentEntryGateway.UpdatedStudent(aStudentEntry);

                if (rowAffected > 0)
                {
                    return "Student Updated Successfully";
                }
                return "Saved Failed";
            }
        }

        public List<StudentEntry> GetAllStudents()
        {
            return aStudentEntryGateway.GetAllStudents();
        }

        public string DeleteStudent(int id)
        {
            int rowAffected = aStudentEntryGateway.DeleteStudent(id);

            if (rowAffected > 0)
            {
                return "Student Deleted Succesfully";
            }
            return "Delete Failed";
        }
    }
}
