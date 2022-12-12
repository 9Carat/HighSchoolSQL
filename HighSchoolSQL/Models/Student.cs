using System;
using System.Collections.Generic;

namespace HighSchoolSQL.Models
{
    public partial class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public int StudId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PersonalNumber { get; set; } = null!;
        public string Class { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
