using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Model
{
    class IndividualResult
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Roll { get; set; }
        public int Marks { get; set; }
        public float Average { get; set; }
        public string LetterGrade { get; set; }
    }
}
