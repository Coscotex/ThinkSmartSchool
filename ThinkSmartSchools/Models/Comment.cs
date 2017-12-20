using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DiscussionId { get; set; }
        public int? StudentId { get; set; }
        public int? StaffId { get; set; }

        public Discussion Discussion { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
    }
}
