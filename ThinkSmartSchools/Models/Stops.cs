using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Stops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RouteId { get; set; }
        public TimeSpan? PickUpTime { get; set; }

        public Route Route { get; set; }
    }
}
