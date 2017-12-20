using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Subject
    {
        public Subject()
        {
            AssignmentResult = new HashSet<AssignmentResult>();
            CaResult = new HashSet<CaResult>();
            CeResult = new HashSet<CeResult>();
            ClassSubject = new HashSet<ClassSubject>();
            Exam = new HashSet<Exam>();
            StaffSubject = new HashSet<StaffSubject>();
            StudentSubject = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public ICollection<AssignmentResult> AssignmentResult { get; set; }
        public ICollection<CaResult> CaResult { get; set; }
        public ICollection<CeResult> CeResult { get; set; }
        public ICollection<ClassSubject> ClassSubject { get; set; }
        public ICollection<Exam> Exam { get; set; }
        public ICollection<StaffSubject> StaffSubject { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
