using System;
using System.Collections.Generic;

namespace HighSchoolSQL.Models
{
    public partial class LastMonthsGrade
    {
        public string CourseName { get; set; } = null!;
        public int Grade { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime GradeDate { get; set; }
    }
}
