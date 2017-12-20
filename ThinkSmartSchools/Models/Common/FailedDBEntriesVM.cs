using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkSmartSchools.Models.Common
{
    public class FailedDBEntriesVM
    {
        public string errorMessage { get; set; }
        public Student student { get; set; }
        public Staff staff { get; set; }
        public Parent parent { get; set; }
        public DataRow failedDataRows { get; set; }
    }
}
