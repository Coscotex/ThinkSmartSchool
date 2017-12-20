using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Fees
    {
        public Fees()
        {
            FeesPaid = new HashSet<FeesPaid>();
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int SchoolId { get; set; }
        public int ClassId { get; set; }
        public int TermId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SessionId { get; set; }

        public Class Class { get; set; }
        public School School { get; set; }
        public Session Session { get; set; }
        public Term Term { get; set; }
        public ICollection<FeesPaid> FeesPaid { get; set; }
    }
}
