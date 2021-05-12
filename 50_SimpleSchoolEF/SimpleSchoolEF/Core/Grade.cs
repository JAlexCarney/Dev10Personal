using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int SectionRosterID { get; set; }
        public int GradeItemID { get; set; }
        public decimal? Score { get; set; }
    }
}
