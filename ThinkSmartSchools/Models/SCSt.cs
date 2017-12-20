using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class SCSt
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int SessionTermId { get; set; }
        public string ClassTRemarks { get; set; }
        public string HeadTRemarks { get; set; }
        public int? Position { get; set; }

        public Class Class { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
    }
}
