using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class SectionRoster
    {
        public int SectionRosterID { get; set; }
        public int SectionID { get; set; }
        public int StudentID { get; set; }
        public decimal? CurrentGrade { get; set; }
    }
}
