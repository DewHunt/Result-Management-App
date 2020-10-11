using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class SubjectEntryManager
    {
        private SubjectEntryGateway aSubjectEntryGateway = new SubjectEntryGateway();

        public string SaveSubject(SubjectEntry aSubjectEntry)
        {
            if (aSubjectEntryGateway.IsSubjectNameExist(aSubjectEntry))
            {
                return "This Subject Already Exists";
            }
            else
            {
                int rowAffected = aSubjectEntryGateway.SaveSubject(aSubjectEntry);

                if (rowAffected > 0)
                {
                    return "Save Subject Succesfully";
                }
                return "Save Failed";
            }
        }

        public string UpdateSubject(SubjectEntry aSubjectEntry)
        {
            if (aSubjectEntryGateway.IsSubjectNameExist(aSubjectEntry))
            {
                return "This Subject Already Exists";
            }
            else
            {
                int rowAffected = aSubjectEntryGateway.UpdateSubject(aSubjectEntry);

                if (rowAffected > 0)
                {
                    return "Update Subject Successfully";
                }
                return "Update Failed";
            }
        }

        public List<SubjectEntry> GetAllSubjects()
        {
            return aSubjectEntryGateway.GetAllSubjects();
        }

        public string DeleteSubject(int id)
        {
            int rowAffected = aSubjectEntryGateway.DeleteSubject(id);

            if (rowAffected > 0)
            {
                return "Delete Subject Successfully";
            }
            return "Delete Failed";
        }
    }
}
