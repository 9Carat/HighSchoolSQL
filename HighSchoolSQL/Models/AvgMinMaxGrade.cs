using System;
using System.Collections.Generic;

namespace HighSchoolSQL.Models
{
    public partial class AvgMinMaxGrade
    {
        public string CourseName { get; set; } = null!;
        public int? AverageGrade { get; set; }
        public int? MinGrade { get; set; }
        public int? MaxGrade { get; set; }
    }
}
