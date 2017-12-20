using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class ResultTypeItem
    {
        public ResultTypeItem()
        {
            AffectiveResult = new HashSet<AffectiveResult>();
            PsycomotResult = new HashSet<PsycomotResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ResultTypeId { get; set; }

        public ResultType ResultType { get; set; }
        public ICollection<AffectiveResult> AffectiveResult { get; set; }
        public ICollection<PsycomotResult> PsycomotResult { get; set; }
    }
}
