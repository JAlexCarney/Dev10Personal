using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class Section
    {
        // Table Properties
        public int SectionID { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public int SemesterID { get; set; }
        public int PeriodID { get; set; }
        public int RoomID { get; set; }

        // Navigation Properties
        public List<SectionRoster> SectionRosters { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Period Period { get; set; }
        public Semester Semester { get; set; }
    }
}
