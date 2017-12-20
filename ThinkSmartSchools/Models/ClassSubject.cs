using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class ClassSubject
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }

        public Class Class { get; set; }
        public Subject Subject { get; set; }
    }
}
