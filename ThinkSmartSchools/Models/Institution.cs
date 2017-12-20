using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Institution
    {
        public Institution()
        {
            Class = new HashSet<Class>();
            Parent = new HashSet<Parent>();
            School = new HashSet<School>();
            SessionTerm = new HashSet<SessionTerm>();
            Staff = new HashSet<Staff>();
            StaffSubject = new HashSet<StaffSubject>();
            Student = new HashSet<Student>();
            Subject = new HashSet<Subject>();
            Term = new HashSet<Term>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ICollection<Class> Class { get; set; }
        public ICollection<Parent> Parent { get; set; }
        public ICollection<School> School { get; set; }
        public ICollection<SessionTerm> SessionTerm { get; set; }
        public ICollection<Staff> Staff { get; set; }
        public ICollection<StaffSubject> StaffSubject { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Subject> Subject { get; set; }
        public ICollection<Term> Term { get; set; }
    }
}
