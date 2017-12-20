using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Student
    {
        public Student()
        {
            AffectiveResult = new HashSet<AffectiveResult>();
            AssignmentResult = new HashSet<AssignmentResult>();
            BookBorrowed = new HashSet<BookBorrowed>();
            CaResult = new HashSet<CaResult>();
            CeResult = new HashSet<CeResult>();
            Comment = new HashSet<Comment>();
            Discussion = new HashSet<Discussion>();
            Exam = new HashSet<Exam>();
            FeesPaid = new HashSet<FeesPaid>();
            PsycomotResult = new HashSet<PsycomotResult>();
            SCSt = new HashSet<SCSt>();
            StudentSubject = new HashSet<StudentSubject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public int? ClassId { get; set; }
        public string Guid { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public int ParentId { get; set; }
        public DateTime? Dob { get; set; }
        public int SchoolId { get; set; }
        public bool Status { get; set; }
        public int InstitutionId { get; set; }

        public Class Class { get; set; }
        public Institution Institution { get; set; }
        public Parent Parent { get; set; }
        public School School { get; set; }
        public ICollection<AffectiveResult> AffectiveResult { get; set; }
        public ICollection<AssignmentResult> AssignmentResult { get; set; }
        public ICollection<BookBorrowed> BookBorrowed { get; set; }
        public ICollection<CaResult> CaResult { get; set; }
        public ICollection<CeResult> CeResult { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Discussion> Discussion { get; set; }
        public ICollection<Exam> Exam { get; set; }
        public ICollection<FeesPaid> FeesPaid { get; set; }
        public ICollection<PsycomotResult> PsycomotResult { get; set; }
        public ICollection<SCSt> SCSt { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
    }
}
