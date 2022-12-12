using System;
using System.Collections.Generic;

namespace HighSchoolSQL.Models
{
    public partial class staff
    {
        public staff()
        {
            Courses = new HashSet<Course>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string StaffRole { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
