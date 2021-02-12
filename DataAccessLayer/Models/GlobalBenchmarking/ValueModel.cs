using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface HasZeroCost
    {
        string ZeroCost
        {
            get; set;
        }
    }
    [SerializableAttribute()]
    public class GroupedValueModel<Type>: IHasValue<Type>
    {
        [XmlAttributeAttribute(AttributeName = "type")]
        [JsonProperty(PropertyName = "type")]
        public string ValueType
        {
            get; set;
        }

        [XmlAttributeAttribute(AttributeName = "group")]
        [JsonProperty(PropertyName = "group")]
        public string Group
        {
            get; set;
        }

        /// <remarks/>
        [XmlTextAttribute]
        [JsonProperty(PropertyName = "value")]
        public Type Value
        {
            get; set;
        }
    }

    [SerializableAttribute()]
    public class GroupedValueModelWithZero<Type> : GroupedValueModel<Type>,  HasZeroCost
    {
        
        [XmlAttributeAttribute(AttributeName = "zeroCost")]
        [JsonProperty(PropertyName = "zeroCost")]
        public string ZeroCost
        {
            get; set;
        }
    }
}
