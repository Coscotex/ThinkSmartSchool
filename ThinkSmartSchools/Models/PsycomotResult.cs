using System;
using System.Collections.Generic;

namespace ThinkSmartSchools.Models
{
    public partial class PsycomotResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SessionTermId { get; set; }
        public int ClassId { get; set; }
        public decimal? Score { get; set; }
        public int ResultTypeItemId { get; set; }

        public Class Class { get; set; }
        public ResultTypeItem ResultTypeItem { get; set; }
        public SessionTerm SessionTerm { get; set; }
        public Student Student { get; set; }
    }
}
