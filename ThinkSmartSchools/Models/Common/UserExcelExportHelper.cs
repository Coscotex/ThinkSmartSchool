using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class UserExcelExportHelper
    {
        private readonly ForSchoolsDBContext _context;
        public List<string> columns = new List<string>();

        public UserExcelExportHelper(ForSchoolsDBContext context)
        {
            _context = context;
        }

        public List<Student> StudentExcelFormat()
        {
            List<Student> students = new List<Student>();
            columns = new List<string>() { "FirstName", "LastName", "OtherNames", "Sex", "Address", "DOB" };
            students.Add(_context.Student.FirstOrDefault());
            return students;
        }

        public List<Staff> StaffExcelFormat()
        {
            List<Staff> staffs = new List<Staff>();
            columns = new List<string>() { "FirstName", "LastName", "OtherNames", "Sex", "Address", "DOB", "Licence_No" };
            staffs.Add(_context.Staff.FirstOrDefault());
            return staffs;
        }

        public List<Parent> ParentExcelFormat()
        {
            List<Parent> parents = new List<Parent>();
            columns = new List<string>() { "FirstName", "LastName", "Address", "DOB" };
            parents.Add(_context.Parent.FirstOrDefault());
            return parents;
        }
    }
}
