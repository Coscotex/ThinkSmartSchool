using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class DriverCar
    {
        public DriverCar()
        {
            CarMaintenance = new HashSet<CarMaintenance>();
        }

        public int Id { get; set; }
        public int CarId { get; set; }
        public int StaffId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Cars Car { get; set; }
        public Staff Staff { get; set; }
        public ICollection<CarMaintenance> CarMaintenance { get; set; }
    }
}
