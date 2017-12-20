using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Guid { get; set; }
        public DateTime? Dob { get; set; }
        public bool Status { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
