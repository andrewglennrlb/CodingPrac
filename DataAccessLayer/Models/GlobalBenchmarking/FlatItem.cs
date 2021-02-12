using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface IRawItem: IHasCode, IHasType
    {
        string Fieldname
        {
            get; set;
        }
    }
    
    [SerializableAttribute()]
    public class FlatItem<ValueType> : IRawItem
    {
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "fieldName")]
        [JsonProperty(PropertyName = "fieldName")]
        public string Fieldname
        {
            get; set;
        }

       
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "type")]
        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get; set;
        }

        [XmlElementAttribute("value", Form = XmlSchemaForm.Unqualified)]
        [JsonProperty(PropertyName = "values")]
        public ValueType[] Value
        {
            get; set;
        }

        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "code")]
        [JsonProperty(PropertyName = "code")]
        public string Code
        {
            get; set;
        }

        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "mappedId")]
        [JsonProperty(PropertyName = "mappedId", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string MappedId
        {
            get; set;
        }

    }
    [SerializableAttribute()]
    public class MeasuredItem<ValueType>: FlatItem<ValueType>, IHasUnit
    {
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "uom")]
        [JsonProperty(PropertyName = "uom")]
        public string UnitOfMeasure
        {
            get; set;
        }
    }
    [SerializableAttribute()]
    public class CostItem : FlatItem<GroupedValueModelWithZero<decimal>>
    {
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "pt")]
        [JsonProperty(PropertyName = "pt")]
        public string ParameterType
        {
            get; set;
        }
    }
}
