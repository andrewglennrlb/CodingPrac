using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface SearchableFieldSet
    {
        string Code { get; set; }
        string Label { get; set; }

        int Count { get; set; }
    }
    public class BaseSearchableSet {
        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "Label")]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "ParentCode")]
        public string ParentCode { get; set; }
    }
    
    [SerializableAttribute()]
    public class MeasuredValues : BaseSearchableSet
    {
        [JsonProperty(PropertyName = "MinValue")]
        public decimal MinValue { get; set; }
        
        [JsonProperty(PropertyName = "MaxValue")]
        public decimal MaxValue { get; set; }

        [JsonProperty(PropertyName = "Average")]
        public decimal Average { get; set; }
    }
}