using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class AssignmentResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal? Assignment1 { get; set; }
        public decimal? Assignment2 { get; set; }
        public decimal? Assignment3 { get; set; }
        public decimal? Assignment4 { get; set; }
        public decimal? Assignment5 { get; set; }
        public int SessionTermId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
