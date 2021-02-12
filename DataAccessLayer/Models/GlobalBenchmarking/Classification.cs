using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{
    [SerializableAttribute()]
    public class Classification : Qualification, IHasSchema
    {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "title")]
        [JsonProperty(PropertyName = "title")]
        public string Title
        {
            get; set;
        }

        [XmlElementAttribute(Form= XmlSchemaForm.Unqualified, ElementName = "country" )]
        [JsonProperty(PropertyName = "country")]
        public CodedType<String> Country
        {
            get; set;
        }

        [XmlElementAttribute(Form= XmlSchemaForm.Unqualified, ElementName = "city" )]
        [JsonProperty(PropertyName = "city")]
        public CodedType<String> City
        {
            get; set;
        }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "rlbOffice")]
        [JsonProperty(PropertyName = "rlbOffice")]
        public CodedType<int> RlbOffice
        {
            get; set;
        }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "currency")]
        [JsonProperty(PropertyName = "currency")]
        public CodedType<string> Currency
        {
            get; set;
        }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "date")]
        [JsonProperty(PropertyName = "date")]
        public DateModel Date
        {
            get; set;
        }

        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "schema")]
        [JsonProperty(PropertyName = "schema")]
        public string Schema
        {
            get; set;
        }

        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "version")]
        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get; set;
        }        

        [XmlElementAttribute("item")]
        [JsonProperty(PropertyName = "items")]
        public FlatItem<string>[] Items
        {
            get; set;
        }      

    }
}
