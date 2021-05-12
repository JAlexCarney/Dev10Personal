using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSchoolEF.Core
{
    public class GradeItem
    {
        public int GradeItemID { get; set; }
        public int GradeTypeID { get; set; }
        public decimal PointsPossible { get; set; }
        public string Description { get; set; }
    }
}
