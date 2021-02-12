using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface IHasUnit
    {
        string UnitOfMeasure
        {
            get; set;
        }
    }
    public interface IHasSymbol
    {
        string Symbol
        {
            get; set;
        }
    }
    public interface IHasValue<ValueType>
    {
        ValueType Value
        {
            get; set;
        }
    }

    public interface IHasSchema
    {
        string Schema
        {
            get; set;
        }
        string Version
        {
            get; set;
        }
    }

    public interface IHasCode
    {
        string Code
        {
            get; set;
        }
    }

    public interface IHasType
    {
        string Type
        {
            get; set;
        }
    }

    [SerializableAttribute()]
    public class CodedType<ValueType>: IHasValue<ValueType>, IHasCode
    {
        [XmlAttributeAttribute( AttributeName = "Code" )]
        [JsonProperty(PropertyName = "Code")]
        public string Code
        {
            get; set;
        }

        /// <remarks/>
        [XmlTextAttribute()]
        [JsonProperty(PropertyName = "value")]
        public ValueType Value
        {
            get; set;
        }

        [XmlAttributeAttribute(AttributeName = "description")]
        [JsonProperty(PropertyName = "description")]
        public string Description
        {
            get; set;
        }
    }

    [SerializableAttribute()]
    public class NestedCodedItem : IHasCode
    {
        [XmlAttributeAttribute(AttributeName = "code")]
        [JsonProperty(PropertyName = "code")]
        public string Code
        {
            get; set;
        }
        [XmlAttributeAttribute(AttributeName = "name")]
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get; set;
        }

        [XmlElementAttribute(ElementName = "bc", IsNullable = true)]
        [JsonProperty(PropertyName = "childClassification")]
        public NestedCodedItem[] ChildClassification
        {
            get; set;
        }

    }

    [SerializableAttribute()]
    public class Groups
    {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "bc")]
        [JsonProperty(PropertyName = "buildingClassification")]
        public NestedCodedItem[] BuildingClassifications
        {
            get; set;
        }
    }
}
