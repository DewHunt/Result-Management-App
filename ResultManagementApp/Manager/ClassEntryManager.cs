using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class ClassEntryManager
    {
        private ClassGateway aClassGateway = new ClassGateway();

        public string SaveClass(ClassEntry aClassEntry)
        {
            if (aClassGateway.IsClassNameExist(aClassEntry))
            {
                return "This Class Already Exists.";
            }
            else
            {
                int rowAffected = aClassGateway.SaveClass(aClassEntry);

                if (rowAffected > 0)
                {
                    return "Save Class Successfuly";
                }
                return "Save Failed";
            }
        }

        public string UpdateClass(ClassEntry aClassEntry)
        {
            if (aClassGateway.IsClassNameExist(aClassEntry))
            {
                return "This Class Already Exists";
            }
            else
            {
                int rowAffected = aClassGateway.UpdateClass(aClassEntry);

                if (rowAffected > 0)
                {
                    return "Update Class Succesfully";
                }
                return "Update Failed";
            }
        }

        public List<ClassEntry> GetAllClasses()
        {
            return aClassGateway.GetAllClasses();
        }

        internal string DeleteClass(int id)
        {
            int rowAffected = aClassGateway.DeleteClass(id);

            if (rowAffected > 0)
            {
                return "Delete Class Successfully";
            }
            return "Delete Failed";
        }
    }
}
