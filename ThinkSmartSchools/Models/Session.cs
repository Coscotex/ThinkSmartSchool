using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Session
    {
        public Session()
        {
            Fees = new HashSet<Fees>();
            SessionTerm = new HashSet<SessionTerm>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public ICollection<Fees> Fees { get; set; }
        public ICollection<SessionTerm> SessionTerm { get; set; }
    }
}
