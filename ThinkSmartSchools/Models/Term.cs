using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Term
    {
        public Term()
        {
            Fees = new HashSet<Fees>();
            SessionTerm = new HashSet<SessionTerm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public ICollection<Fees> Fees { get; set; }
        public ICollection<SessionTerm> SessionTerm { get; set; }
    }
}
