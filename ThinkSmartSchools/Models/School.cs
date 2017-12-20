using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class School
    {
        public School()
        {
            Book = new HashSet<Book>();
            Cars = new HashSet<Cars>();
            Class = new HashSet<Class>();
            Discussion = new HashSet<Discussion>();
            Fees = new HashSet<Fees>();
            Grade = new HashSet<Grade>();
            ResultType = new HashSet<ResultType>();
            Staff = new HashSet<Staff>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public ICollection<Book> Book { get; set; }
        public ICollection<Cars> Cars { get; set; }
        public ICollection<Class> Class { get; set; }
        public ICollection<Discussion> Discussion { get; set; }
        public ICollection<Fees> Fees { get; set; }
        public ICollection<Grade> Grade { get; set; }
        public ICollection<ResultType> ResultType { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
