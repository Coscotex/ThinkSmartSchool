using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class ResultType
    {
        public ResultType()
        {
            ResultTypeItem = new HashSet<ResultTypeItem>();
        }

        public int Id { get; set; }
        public int AssessmentTypeId { get; set; }
        public int SchoolId { get; set; }
        public decimal MaxScore { get; set; }
        public int? NoOfItems { get; set; }

        public AssessmentType AssessmentType { get; set; }
        public School School { get; set; }
        public ICollection<ResultTypeItem> ResultTypeItem { get; set; }
    }
}
