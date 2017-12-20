using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class AssessmentType
    {
        public AssessmentType()
        {
            ResultType = new HashSet<ResultType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ResultType> ResultType { get; set; }
    }
}
