using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class ResultTypeCreateViewModel
    {
        public int ID { get; set; }
        public decimal MaxScore { get; set; }
        public int NoOfItems { get; set; }
        public string Name { get; set; }
    }
}
