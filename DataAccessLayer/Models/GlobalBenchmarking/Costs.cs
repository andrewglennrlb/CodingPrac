using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RLBPulse.GlobalBenchmarking.Models
{
    [SerializableAttribute()]
    public class TotalCost : IHasValue<decimal>
    {
        
        /// <remarks/>
        [XmlAttributeAttribute(AttributeName = "currencyCode")]
        [JsonProperty(PropertyName = "currencyCode")]
        public string CurrencyCode
        {
            get; set;
        }

        /// <remarks/>
        [XmlAttributeAttribute(AttributeName = "value")]
        [JsonProperty(PropertyName = "value")]
        public decimal Value
        {
            get; set;
        }

    }
    [SerializableAttribute()]
    public class Costs : IHasSchema
    {
        [XmlElementAttribute(ElementName = "totalCost")]
        [JsonProperty(PropertyName = "totalCost")]
        public TotalCost TotalCost
        {
            get; set;
        }

        [XmlElementAttribute("item")]
        [JsonProperty(PropertyName = "items")]
        public CostItem[] CostItems
        {
            get; set;
        }

        [XmlAttributeAttribute(AttributeName = "schema")]
        [JsonProperty(PropertyName = "schema")]
        public string Schema { get; set; }

        [XmlAttributeAttribute(AttributeName = "schemaFrom")]
        [JsonProperty(PropertyName = "schemaFrom")]
        public string SchemaFromId { get; set; }

        [XmlAttributeAttribute(AttributeName = "schemaTo")]
        [JsonProperty(PropertyName = "schemaTo")]
        public string SchemaToId { get; set; }

        [XmlAttributeAttribute(AttributeName = "mappingFileId")]
        [JsonProperty(PropertyName = "mappingFileId")]
        public string MappingFileId { get; set; }

        [XmlAttributeAttribute(AttributeName = "version")]
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
