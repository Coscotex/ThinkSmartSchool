using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class ResultTypeGradeViewModel
    {
        private readonly ForSchoolsDBContext _context;
        public IEnumerable<ResultType> ResultTypes { get; set; }
        public IEnumerable<Grade> Grades { get; set; }

        public IEnumerable<string> ResultItemNames { get; set; }

        public ResultTypeGradeViewModel(ForSchoolsDBContext context)
        {
            _context = context;
            Grades = _context.Grade.ToList();
            ResultTypes = _context.ResultType.ToList();
        }
    }
}
