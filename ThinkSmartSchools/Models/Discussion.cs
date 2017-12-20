using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Discussion
    {
        public Discussion()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int SchoolId { get; set; }
        public int? StudentId { get; set; }
        public int? StaffId { get; set; }

        public School School { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
        public ICollection<Comment> Comment { get; set; }
    }
}
