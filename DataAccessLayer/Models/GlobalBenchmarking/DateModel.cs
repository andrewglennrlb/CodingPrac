using System;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml.Schema;
namespace RLBPulse.GlobalBenchmarking.Models
{
    [SerializableAttribute()]
    public class DateModel
    {
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "format")]
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        [XmlTextAttribute()]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }        
    }
}

