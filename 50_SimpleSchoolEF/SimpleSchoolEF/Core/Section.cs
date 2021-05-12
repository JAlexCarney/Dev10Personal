using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class Section
    {
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public int SemesterID { get; set; }
        public int PeriodID { get; set; }
        public int RoomID { get; set; }
    }
}
