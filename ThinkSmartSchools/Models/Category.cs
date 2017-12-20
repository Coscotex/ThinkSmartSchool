using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
