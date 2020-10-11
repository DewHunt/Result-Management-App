using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Model
{
    class ClassWiseResult
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int TotalStudent { get; set; }
        public float Passed { get; set; }
        public float Failed { get; set; }
        public float TotalMarks { get; set; }
        public float Average { get; set; }
        public string LetterGrade { get; set; }
    }
}
