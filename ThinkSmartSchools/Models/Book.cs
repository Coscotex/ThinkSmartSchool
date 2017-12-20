using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Book
    {
        public Book()
        {
            BookBorrowed = new HashSet<BookBorrowed>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
        public int Copies { get; set; }
        public string Publisher { get; set; }
        public int SchoolId { get; set; }

        public Category Category { get; set; }
        public School School { get; set; }
        public ICollection<BookBorrowed> BookBorrowed { get; set; }
    }
}
