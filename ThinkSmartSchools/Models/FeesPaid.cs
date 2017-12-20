using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class FeesPaid
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int FeesId { get; set; }
        public decimal AmountPaid { get; set; }

        public Fees Fees { get; set; }
        public Student Student { get; set; }
    }
}
