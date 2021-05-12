using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class Course
    {
        public int CourseID { get; set; }
        public int SubjectID { get; set; }
        public string CourseName { get; set; }
        public decimal CreditHours { get; set; }
    }
}
