using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Cars
    {
        public Cars()
        {
            DriverCar = new HashSet<DriverCar>();
        }

        public int Id { get; set; }
        public string ModelName { get; set; }
        public string PlateNumber { get; set; }
        public int NoOfSeats { get; set; }
        public int SchoolId { get; set; }
        public int? DriverId { get; set; }
        public int? Servicing { get; set; }

        public Staff Driver { get; set; }
        public School School { get; set; }
        public ICollection<DriverCar> DriverCar { get; set; }
    }
}
