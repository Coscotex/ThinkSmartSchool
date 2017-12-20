using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class CarMaintenance
    {
        public int Id { get; set; }
        public int DriverCarId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public decimal Amount { get; set; }
        public bool? IsService { get; set; }

        public DriverCar DriverCar { get; set; }
    }
}
