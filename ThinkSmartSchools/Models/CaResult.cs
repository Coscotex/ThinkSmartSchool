using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class CaResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal? FirstCa { get; set; }
        public decimal? SecondCa { get; set; }
        public decimal? ThirdCa { get; set; }
        public decimal? FourthCa { get; set; }
        public decimal? FifthCa { get; set; }
        public int SessionTermId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
