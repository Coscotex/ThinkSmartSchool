using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }

        public School School { get; set; }
    }
}
