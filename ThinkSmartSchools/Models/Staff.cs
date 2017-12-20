using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class Staff
    {
        public Staff()
        {
            BookBorrowed = new HashSet<BookBorrowed>();
            Cars = new HashSet<Cars>();
            Class = new HashSet<Class>();
            Comment = new HashSet<Comment>();
            Discussion = new HashSet<Discussion>();
            DriverCar = new HashSet<DriverCar>();
            News = new HashSet<News>();
            Route = new HashSet<Route>();
            Salary = new HashSet<Salary>();
            StaffSubject = new HashSet<StaffSubject>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Sex { get; set; }
        public string Guid { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public int SchoolId { get; set; }
        public bool Status { get; set; }
        public string LicenceNo { get; set; }
        public int InstitutionId { get; set; }

        public Institution Institution { get; set; }
        public School School { get; set; }
        public ICollection<BookBorrowed> BookBorrowed { get; set; }
        public ICollection<Cars> Cars { get; set; }
        public ICollection<Class> Class { get; set; }
        public ICollection<Comment> Comment { get; set; }
        public ICollection<Discussion> Discussion { get; set; }
        public ICollection<DriverCar> DriverCar { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Route> Route { get; set; }
        public ICollection<Salary> Salary { get; set; }
        public ICollection<StaffSubject> StaffSubject { get; set; }
    }
}
