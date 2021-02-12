using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RLBPulse.GlobalBenchmarking.Models
{
    [SerializableAttribute()]
    public class MaxFloorArea: IHasValue<decimal>
    {
        [XmlAttributeAttribute(AttributeName = "uom")]
        [JsonProperty(PropertyName = "uom")]

        public string UnitOfMeasure
        {
            get; set;
        }

        [XmlAttributeAttribute(AttributeName = "measuredField")]
        [JsonProperty(PropertyName = "measuredField")]
        public string MeasuredField
        {
            get; set;
        }
        [XmlTextAttribute()]
        [JsonProperty(PropertyName = "value")]
        public decimal Value
        {
            get; set;
        }
    }


    [SerializableAttribute()]
    public class Measurements: IHasSchema
    {
        [XmlElementAttribute(ElementName = "functionalUnits")]
        [JsonProperty(PropertyName = "functionalUnits")]
        public MeasuredItem<GroupedValueModel<decimal>>[] FunctionalUnits
        {
            get; set;
        }

        [XmlAttributeAttribute(AttributeName = "schema")]
        [JsonProperty(PropertyName = "schema")]
        public string Schema
        {
            get; set;
        }
        [XmlAttributeAttribute(AttributeName = "version")]
        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get; set;
        }
        [XmlElementAttribute(ElementName = "maxFloorArea")]
        [JsonProperty(PropertyName = "maxFloorArea")]
        public MaxFloorArea MaxFloorArea
        {
            get; set;
        }

        [XmlElementAttribute(ElementName = "IPMS1")]
        [JsonProperty(PropertyName = "IPMS1")]
        public MeasuredItem<GroupedValueModel<decimal>> Ipms1
        {
            get; set;
        }

        [XmlElementAttribute(ElementName = "IPMS2")]
        [JsonProperty(PropertyName = "IPMS2")]
        public MeasuredItem<GroupedValueModel<decimal>> Ipms2
        {
            get; set;
        }

        [XmlElementAttribute("item")]
        [JsonProperty(PropertyName = "items")]
        public MeasuredItem<GroupedValueModel<decimal>>[] Items
        {
            get; set;
        }
    }
    
}
