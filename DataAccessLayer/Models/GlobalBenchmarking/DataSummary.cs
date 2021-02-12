using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RLBPulse.GlobalBenchmarking.Models
{    
    public class ExemplarSummary
    {
        public string Id { get; set; }
        public string Title { get; set; }                
    }
    public class DataSummary
    {
        public int TotalCount { get; set; }
        public IEnumerable<ExemplarSummary> Entries { get; set; }
    }
}
