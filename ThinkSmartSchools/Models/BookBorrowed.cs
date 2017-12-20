using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class BookBorrowed
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int? StaffId { get; set; }
        public int? StudentId { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime TimeBorrowed { get; set; }

        public Book Book { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
    }
}
