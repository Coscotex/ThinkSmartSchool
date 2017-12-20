using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Class
    {
        public Class()
        {
            AffectiveResult = new HashSet<AffectiveResult>();
            AssignmentResult = new HashSet<AssignmentResult>();
            CaResult = new HashSet<CaResult>();
            CeResult = new HashSet<CeResult>();
            ClassSubject = new HashSet<ClassSubject>();
            Exam = new HashSet<Exam>();
            Fees = new HashSet<Fees>();
            PsycomotResult = new HashSet<PsycomotResult>();
            SCSt = new HashSet<SCSt>();
            StaffSubject = new HashSet<StaffSubject>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public int StaffId { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public School School { get; set; }
        public Staff Staff { get; set; }
        public ICollection<AffectiveResult> AffectiveResult { get; set; }
        public ICollection<AssignmentResult> AssignmentResult { get; set; }
        public ICollection<CaResult> CaResult { get; set; }
        public ICollection<CeResult> CeResult { get; set; }
        public ICollection<ClassSubject> ClassSubject { get; set; }
        public ICollection<Exam> Exam { get; set; }
        public ICollection<Fees> Fees { get; set; }
        public ICollection<PsycomotResult> PsycomotResult { get; set; }
        public ICollection<SCSt> SCSt { get; set; }
        public ICollection<StaffSubject> StaffSubject { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
