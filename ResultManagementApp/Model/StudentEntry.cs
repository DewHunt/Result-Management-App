using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultManagementApp.Model
{
    class StudentEntry
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Roll { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int OrderBy { get; set; }
        public string ClassName { get; set; }
    }
}
