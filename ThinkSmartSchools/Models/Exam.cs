using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Exam
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal? Score { get; set; }
        public int SessionTermId { get; set; }
        public string Remark { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
