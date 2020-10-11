using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class ResultEntryManager
    {
        private ResultEntryGateway aResultEntryGateway = new ResultEntryGateway();
        private ClassGateway aClassGateway = new ClassGateway();
        private StudentEntryGateway aStudentEntryGateway = new StudentEntryGateway();
        private SubjectEntryGateway aSubjectEntryGateway = new SubjectEntryGateway();

        public List<ClassEntry> GetAllClasses()
        {
            return aClassGateway.GetAllClasses();
        }

        public List<StudentEntry> GetAllStudentsByClass(int classId)
        {
            return aStudentEntryGateway.GetAllStudentsByClass(classId);
        }

        public StudentEntry GetStudentInfoById(int studentId)
        {
            return aStudentEntryGateway.GetStudentInfoById(studentId);
        }

        public List<SubjectEntry> GetAllSubjects()
        {
            return aSubjectEntryGateway.GetAllSubjects();
        }

        public string SaveResult(ResultEntry aResultEntry)
        {
            if (aResultEntryGateway.IsResultExists(aResultEntry))
            {
                return "This Result Already Saved  With This Subjects For This Student";
            }
            else
            {
                int rowAffected = aResultEntryGateway.SaveResult(aResultEntry);

                if (rowAffected > 0)
                {
                    return "Result Saved Successfully";
                }
                return "Saved Failed";

            }
        }

        public List<ResultEntry> GetAllResults()
        {
            return aResultEntryGateway.GetAllResults();
        }

        public string UpdateResult(ResultEntry aResultEntry)
        {
            if (aResultEntryGateway.IsResultExists(aResultEntry))
            {
                return "This Result Already Saved  With This Subjects For This Student";
            }
            else
            {
                int rowAffected = aResultEntryGateway.UpdateResult(aResultEntry);

                if (rowAffected > 0)
                {
                    return "Update Result Successfully";
                }
                return "Update Failed";
            }
        }

        public string DeleteResult(int id)
        {
            int rowAffected = aResultEntryGateway.DeleteResult(id);

            if (rowAffected > 0)
            {
                return "Delete Result Successfully";
            }
            return "Delete Failed";
        }
    }
}
