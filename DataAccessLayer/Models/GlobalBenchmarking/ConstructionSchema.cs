using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
using RLBPulse.GlobalBenchmarking.Security;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using RLBPulse.GlobalBenchmarking.Document;
using System.Runtime.Serialization;


namespace RLBPulse.GlobalBenchmarking.Models
{
    /// <summary>
    /// Not my model - I will drop this from the View API but this will better support importing from:
    /// https://www.graphisoft.com/downloads/archicad/BIM_Data.html
    /// </summary>
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(ElementName = "BuildingInformation", IsNullable = false)]
    [KnownType(typeof(RLBPulse.GlobalBenchmarking.Models.Exemplar))]
    public class BuildingInformation
    {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Classification")]
        [JsonProperty(PropertyName = "Classification")]
        [DataMember(Name = "Classification")]
        public ConstructionSchema Classification { get; set; }
    }
    [SerializableAttribute()]
    public class ConstructionSchema
    {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Classification")]
        [JsonProperty(PropertyName = "Classification")]
        [DataMember(Name = "Classification")]
        public ConstructionSchemaSystem System { get; set; }
    }

    [SerializableAttribute()]
    [XmlRootAttribute(ElementName = "System", IsNullable = false)]
    public class ConstructionSchemaSystem : IDocument<string>, IEquatable<ConstructionSchemaSystem>
    {

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Name")]
        [JsonProperty(PropertyName = "Name")]
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "EditionVersion")]
        [JsonProperty(PropertyName = "EditionVersion")]
        [DataMember(Name = "EditionVersion")]
        public string EditionVersion { get; set; }
        

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Description")]
        [JsonProperty(PropertyName = "Description")]
        [DataMember(Name = "Description")]
        public string Description { get; set;  }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "EditionDate")]
        [JsonProperty(PropertyName = "EditionDate")]
        [DataMember(Name = "EditionDate")]
        public EditionDate EditionDate { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Source")]
        [JsonProperty(PropertyName = "Source")]
        [DataMember(Name = "Source")]
        public string Source{ get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Item")]
        [JsonProperty(PropertyName = "Items")]
        [DataMember(Name = "Items")]
        public SchemaItem[] Items { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Id")]
        [JsonProperty(PropertyName = "id")]
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "DocumentType")]
        [JsonProperty(PropertyName = "documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "DocumentType")]
        public SupportedDocuments DocumentType { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "createdBy")]
        [JsonProperty(PropertyName = "createdBy")]
        [DataMember(Name = "createdBy")]
        public string CreatedBy { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "scope")]
        [JsonProperty(PropertyName = "scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "scope")]
        public SecureScope Scope { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "RlbOffice")]
        [JsonProperty(PropertyName = "RlbOffice")]
        [DataMember(Name = "RlbOffice")]
        public CodedType<int> RlbOffice { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "MappedId")]
        [JsonProperty(PropertyName = "MappedId")]
        [DataMember(Name = "MappedId")]
        public int MappedId { get; set; }

        public bool Equals(ConstructionSchemaSystem other)
        {
            string otherData = JsonConvert.SerializeObject(other);
            string thisStr = JsonConvert.SerializeObject(this);
            return otherData.Equals(thisStr);
        }
    }
   
    [SerializableAttribute()]
    public class SchemaItem
    {

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "ID")]
        [JsonProperty(PropertyName = "Id")]
        [DataMember(Name = "ID")]
        public string Id { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Name")]
        [JsonProperty(PropertyName = "fieldName")]
        [DataMember(Name = "FieldName")]
        public string FieldName { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Code")]
        [JsonProperty(PropertyName = "code", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [XmlArray(Form = XmlSchemaForm.Unqualified, ElementName = "Children")]
        [XmlArrayItem(Form = XmlSchemaForm.Unqualified, ElementName = "Item")]
        [JsonProperty(PropertyName = "Children")]
        [DataMember(Name = "Children")]
        public SchemaItem[] Children { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Availability")]
        [JsonProperty(PropertyName = "Availability")]
        [DataMember(Name = "Availability")]
        public string Availability { get; set;  }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Description")]
        [JsonProperty(PropertyName = "description")]
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "MappedId")]
        [JsonProperty(PropertyName = "mappedId")]
        [DataMember(Name = "MappedId")]
        public Guid MappedId { get; set; }
    }
    [Serializable()]
    public class EditionDate
    {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Year")]
        [JsonProperty(PropertyName = "Year")]
        [DataMember(Name = "Year")]
        public int Year { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Month")]
        [JsonProperty(PropertyName = "Month")]
        [DataMember(Name = "Month")]
        public int Month { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "Day")]
        [JsonProperty(PropertyName = "Day")]
        [DataMember(Name = "Day")]
        public int Day{ get; set; }
    }
}
