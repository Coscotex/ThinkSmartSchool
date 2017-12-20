using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Staff Staff { get; set; }
    }
}
