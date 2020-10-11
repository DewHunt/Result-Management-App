using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class IndividualResultManager
    {
        private IndividualResultGateway aIndividualResultGateway = new IndividualResultGateway();
        private ClassGateway aClassGateway = new ClassGateway();
        private StudentEntryGateway aStudentEntryGateway = new StudentEntryGateway();

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

        public float GetResultAverage(int studenId)
        {
            return aIndividualResultGateway.GetResultAverage(studenId);
        }

        public List<IndividualResult> GetAllSubjectResults(int studenId)
        {
            List<IndividualResult> allSubjectResultInfo = aIndividualResultGateway.GetAllSubjectResults(studenId);

            List<IndividualResult> allSubjectResultWithLetterGrade = new List<IndividualResult>();

            foreach (IndividualResult aSubjectResultInfo in allSubjectResultInfo)
            {
                IndividualResult subjectResultInfo = new IndividualResult();

                subjectResultInfo.SubjectName = aSubjectResultInfo.SubjectName;
                subjectResultInfo.Marks = aSubjectResultInfo.Marks;
                subjectResultInfo.LetterGrade = GetLetterGrade(aSubjectResultInfo.Marks);

                allSubjectResultWithLetterGrade.Add(subjectResultInfo);
            }

            return allSubjectResultWithLetterGrade;
        }

        private string GetLetterGrade(int marks)
        {
            string letterGrade = "";

            if (marks >= 80 && marks <= 100)
            {
                letterGrade = "A+";
            }
            else if (marks >= 70 && marks <= 79)
            {
                letterGrade = "A";
            }
            else if (marks >= 60 && marks <= 69)
            {
                letterGrade = "A-";
            }
            else if (marks >= 50 && marks <= 59)
            {
                letterGrade = "B";
            }
            else if (marks >= 40 && marks <= 49)
            {
                letterGrade = "C";
            }
            else if (marks >= 33 && marks <= 39)
            {
                letterGrade = "D";
            }
            else
            {
                letterGrade = "F";
            }

            return letterGrade;
        }
    }
}
