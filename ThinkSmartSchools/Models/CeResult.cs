using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class CeResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal? ClassExercise1 { get; set; }
        public decimal? ClassExercise2 { get; set; }
        public decimal? ClassExercise3 { get; set; }
        public decimal? ClassExercise4 { get; set; }
        public decimal? ClassExercise5 { get; set; }
        public int SessionTermId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
