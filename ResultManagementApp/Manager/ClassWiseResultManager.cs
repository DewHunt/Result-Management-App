using ResultManagementApp.Gateway;
using ResultManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Manager
{
    class ClassWiseResultManager
    {
        private ClassWiseResultGateway aClassWiseResultGateway = new ClassWiseResultGateway();
        private ClassGateway aClassGateway = new ClassGateway();
        private StudentEntryGateway aStudentEntryGateway = new StudentEntryGateway();

        public List<ClassEntry> GetAllClasses()
        {
            return aClassGateway.GetAllClasses();
        }

        public List<StudentEntry> CalculateTotalStudentInClass(int classId)
        {
            return aStudentEntryGateway.GetAllStudentsByClass(classId);
        }

        public ClassWiseResult CalculatePassedFailedPercentage(int classId)
        {
            float averageResult = 0;
            float passedPercentage = 0;
            float failedPercentage = 0;
            int passedStudent = 0;
            int failedStudent = 0;

            List<ClassWiseResult> allStudentResults = aClassWiseResultGateway.GetAllStudentResultsByClass(classId);

            foreach (ClassWiseResult aStudentResult in allStudentResults)
            {
                averageResult = aStudentResult.TotalMarks / 3;

                if (averageResult >= 33)
                {
                    passedStudent++;
                }
                else
                {
                    failedStudent++;
                }
            }

            passedPercentage = ((float)passedStudent / (float)allStudentResults.Count()) * 100;
            failedPercentage = ((float)failedStudent / (float)allStudentResults.Count()) * 100;

            ClassWiseResult passedFailedPercentage = new ClassWiseResult();

            passedFailedPercentage.Passed = passedPercentage;
            passedFailedPercentage.Failed = failedPercentage;

            return passedFailedPercentage;
        }

        public List<ClassWiseResult> GetAllStudentsResultInfoByClass(int classId)
        {
            float averageResult = 0;
            string letterGrade = "";

            List<ClassWiseResult> allStudentResults = aClassWiseResultGateway.GetAllStudentResultsByClass(classId);

            List<ClassWiseResult> allStudentResultsInformation = new List<ClassWiseResult>();

            foreach (ClassWiseResult aStudentResult in allStudentResults)
            {
                ClassWiseResult aStudentResultInfo = new ClassWiseResult();

                averageResult = aStudentResult.TotalMarks / 3;
                letterGrade = GetLetterGrade(averageResult);

                aStudentResultInfo.StudentName = aStudentResult.StudentName;
                aStudentResultInfo.TotalMarks = aStudentResult.TotalMarks;
                aStudentResultInfo.Average = averageResult;
                aStudentResultInfo.LetterGrade = letterGrade;

                allStudentResultsInformation.Add(aStudentResultInfo);
            }

            return allStudentResultsInformation;
        }

        private string GetLetterGrade(float marks)
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
