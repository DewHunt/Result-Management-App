using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Model
{
    class ResultEntry
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Marks { get; set; }
        public int ClassId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string Phone { get; set; }
        public string Roll { get; set; }
        public string SubjectName { get; set; }
    }
}
