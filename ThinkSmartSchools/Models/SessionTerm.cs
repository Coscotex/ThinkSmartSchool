using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class SessionTerm
    {
        public SessionTerm()
        {
            AffectiveResult = new HashSet<AffectiveResult>();
            AssignmentResult = new HashSet<AssignmentResult>();
            CaResult = new HashSet<CaResult>();
            CeResult = new HashSet<CeResult>();
            Exam = new HashSet<Exam>();
            PsycomotResult = new HashSet<PsycomotResult>();
            SCSt = new HashSet<SCSt>();
        }

        public int Id { get; set; }
        public int SessionId { get; set; }
        public int TermId { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public Session Session { get; set; }
        public Term Term { get; set; }
        public ICollection<AffectiveResult> AffectiveResult { get; set; }
        public ICollection<AssignmentResult> AssignmentResult { get; set; }
        public ICollection<CaResult> CaResult { get; set; }
        public ICollection<CeResult> CeResult { get; set; }
        public ICollection<Exam> Exam { get; set; }
        public ICollection<PsycomotResult> PsycomotResult { get; set; }
        public ICollection<SCSt> SCSt { get; set; }
    }
}
