using System;
using System.Collections.Generic;

namespace HighSchoolSQL.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int Grade { get; set; }
        public DateTime GradeDate { get; set; }
        public int FkTeacherId { get; set; }
        public int FkStudId { get; set; }

        public virtual Student FkStud { get; set; } = null!;
        public virtual staff FkTeacher { get; set; } = null!;
    }
}
