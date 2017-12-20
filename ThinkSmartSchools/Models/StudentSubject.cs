using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
