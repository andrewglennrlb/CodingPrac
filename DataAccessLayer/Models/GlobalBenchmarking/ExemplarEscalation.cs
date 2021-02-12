
using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{

    public static class SupportedEscalations
    {
        public const int NONE = 0;
        public const int ESCALATION_ONLY = 1;
        public const int RELATIVITY_ONLY = 2;
        public const int ESCALATIONandRELATIVITY = 3;
        public const int TOTAL_OPTIONS = 3;
    }
    
    public interface IEscalationContext
    {
        [JsonProperty(PropertyName = "EscalationIndex")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "EscalationIndex", IsNullable = true)]        
        decimal EscalationIndex { get; set; }

        [JsonProperty(PropertyName = "RelativityIndex")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "RelativityIndex", IsNullable = true)]
        decimal RelativityIndex { get; set; }

        [JsonProperty(PropertyName = "ExchangeRate")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "ExchangeRate", IsNullable = true)]
        decimal ExchangeRate { get; set; }

        [JsonProperty(PropertyName = "LocationAdjustment")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "LocationAdjustment", IsNullable = true)]
        decimal LocationAdjustment { get; set; }
    }

    public class EscalationSelection : IEscalationContext
    {
[JsonProperty(PropertyName = "escalationMultiplier")]
        public decimal EscalationMultiplier { get; set; }
        
        [XmlIgnore()]
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [XmlIgnore()]
        [JsonProperty(PropertyName = "ApprovedExemplarId")]
        public string ApprovedExemplarId { get; set; }

        [JsonProperty(PropertyName = "escalationIndex")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "EscalationIndex")]
        public decimal EscalationIndex { get; set; }
        
        [JsonProperty(PropertyName = "relativityIndex")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "RelativityIndex")]
        public decimal RelativityIndex { get; set; }
        
        [JsonProperty(PropertyName = "exchangeRate")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "ExchangeRate")]
        public decimal ExchangeRate { get; set; }
        
        [JsonProperty(PropertyName = "locationAdjustment")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "LocationAdjustment")]
        public decimal LocationAdjustment { get; set; }
    }

    public class SelectManyInput
    {
        [JsonProperty(PropertyName = "Selection")]
        public EscalationSelection[] Selection { get; set; }

        [JsonProperty(PropertyName = "Settings")]
        public ExemplarSearchSettings Settings { get; set; }
    }
}