using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolADODAL
{
    public class Section
    {
        public int SectionId;
        public string CourseName;
        public DateTime StartDate;
        public DateTime EndDate;
        public string Teacher;
        public List<Student> Students;
    }
}
