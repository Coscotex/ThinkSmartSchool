using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class StaffSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int InstitutionId { get; set; }
        public int StaffId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public Institution Institution { get; set; }
        public Staff Staff { get; set; }
        public Subject Subject { get; set; }
    }
}
