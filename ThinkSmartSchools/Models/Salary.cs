using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Salary
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public decimal Amount { get; set; }
        public decimal Penalty { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Staff Staff { get; set; }
    }
}
