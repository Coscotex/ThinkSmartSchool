using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class ExtraFees
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string StudentGuid { get; set; }
    }
}
