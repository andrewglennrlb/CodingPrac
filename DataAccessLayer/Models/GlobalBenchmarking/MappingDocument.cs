using Dapper.Contrib.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RLBPulse.GlobalBenchmarking.Document;
using RLBPulse.GlobalBenchmarking.Security;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace RLBPulse.GlobalBenchmarking.Models
{
    [Serializable()]
    [KnownType(typeof(RLBPulse.GlobalBenchmarking.Models.MappingDocument))]
    public class MappingDocument : IDocument<Guid>, IEquatable<MappingDocument>
    {
        /// <summary>
        /// Identifier will become a guid to string
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Document Type is for document state
        /// </summary>
        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SupportedDocuments DocumentType { get; set; }

        /// <summary>
        /// Created by is for governance and access rights
        /// </summary>
        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Scope is used for Access rights
        /// </summary>
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureScope Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "rlbOffice")]
        [Computed]
        public CodedType<int> RlbOffice { get; set; }

        [JsonProperty(PropertyName = "ofice")]
        public int OfficeId { get; set; }

        /// <summary>
        /// Created by is for governance and access rights
        /// </summary>
        [JsonProperty("schemaFrom")]
        public string SchemaFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MappedSchemaFromId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MappedSchemaToId { get; set; }

        /// <summary>
        /// Created by is for governance and access rights
        /// </summary>
        [JsonProperty("schemaTo")]
        public Guid SchemaTo { get; set; }

        /// <summary>
        /// Created by is for governance and access rights
        /// </summary>
        [JsonProperty("mapping")]
        public Dictionary<string, MappingType>  Mapping { get; set; }


        [JsonIgnore]
        public string Data { get; set; }

        /// <summary>
        /// For updating documents - should only update if changed
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MappingDocument other)
        {
            return (JsonConvert.SerializeObject(other) == JsonConvert.SerializeObject(this));
        }

    }
    [Serializable()]
    public class MappingType {

        [JsonProperty("mapping")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SupportMappingTypes Mapping
        {
            get; set;
        }

        [JsonProperty("mappedParameterId")]        
        public Guid MappedParameterId
        {
            get; set;
        }

        [JsonProperty("input")]
        public List<FieldMapping> MappedItems { get; set; }

    }

    [Serializable()]
    public class FieldMapping
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("function")]
        public string Function { get; set; }

        [JsonProperty("mappedParameterId")]
        public Guid MappedParameterId
        {
            get; set;
        }

    }

    [Serializable()]
    public enum SupportMappingTypes
    {
        heirarchicalCalculation = 1,
        directCalculation = 2,
        directValue = 3,
        unmapped = 4,
        calculation = 5
    }
}
