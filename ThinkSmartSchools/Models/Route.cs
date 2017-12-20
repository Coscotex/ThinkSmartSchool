using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Route
    {
        public Route()
        {
            Stops = new HashSet<Stops>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StaffId { get; set; }

        public Staff Staff { get; set; }
        public ICollection<Stops> Stops { get; set; }
    }
}
