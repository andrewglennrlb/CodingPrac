using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
using RLBPulse.GlobalBenchmarking.Security;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using RLBPulse.GlobalBenchmarking.Document;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Linq;
using RLBPulse.GlobalBenchmarking.Mapping;
using System.Globalization;
using RLBPulse.GlobalBenchmarking.Measurement;
using System.Collections.Generic;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public struct MeasurementVariable
    {
        
        public decimal Value { get;  }
        public string Code { get; }
        public string UnitOfMeasure { get; set; }

        public MeasurementVariable(decimal value, string code)
        {
            Value = value;
            Code = code;
            UnitOfMeasure = "m²";
        }
    }

    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", ElementName = "exemplar", IsNullable = false)]
    [KnownType(typeof(RLBPulse.GlobalBenchmarking.Models.Exemplar))]
    public class Exemplar : IDocument<string>, IEquatable<Exemplar>
    {
        public const string ComplexProjectKey = "MultiClass";
        public const string NotSetKey = "Not Set";
        public const string EightCharacterDateFormat = "ddMMyyyy";
        public const string TOTAL_COST_PARAMETER_ID = "C17C1C0A-CEEA-4F63-A924-D1CC2ECD794F";
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "groups")]
        [JsonProperty(PropertyName = "groups")]
        [DataMember(Name = "groups")]
        public Groups Groups
        {
            get; set;
        }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "classification")]
        [JsonProperty(PropertyName = "classification")]
        [DataMember(Name = "classification")]
        public Classification Classification
        {
            get; set;
        }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "escalationData", IsNullable = true)]
        [JsonProperty(PropertyName = "escalationData", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DataMember(Name = "escalationData", IsRequired = false)]
        public EscalationSelection EscalationData
        {
            get; set;
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "measurements")]
        [JsonProperty(PropertyName = "measurements")]
        [DataMember(Name = "measurements")]
        public Measurements Measurements
        {
            get; set;
        }

        /// <remarks/>
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "costs")]
        [JsonProperty(PropertyName = "costs")]
        [DataMember(Name = "costs")]
        public Costs Costs
        {
            get; set;
        }

        /// <summary>
        /// The primary key
        /// </summary>
        [Required]
        [XmlAttributeAttribute(Form = XmlSchemaForm.Unqualified, AttributeName = "id" )]
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get; set;
        }
        [XmlAttributeAttribute(AttributeName = "rateType")]
        [JsonProperty(PropertyName = "rateType")]
        public string RateType
        {
            get; set;
        }
        [XmlAttributeAttribute(AttributeName = "documentType")]
        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SupportedDocuments DocumentType { get; set; }

        [XmlAttributeAttribute(AttributeName = "createdBy")]
        [JsonProperty("createdBy")]        
        public string CreatedBy { get; set;  }

        [XmlAttributeAttribute(AttributeName = "createdById")]
        [JsonProperty("createdById")]        
        public int createdById { get; set; }

        [XmlAttributeAttribute(AttributeName = "approvedBy")]
        [JsonProperty("approvedBy")]
        public string approvedBy { get; set; }

        [XmlAttributeAttribute(AttributeName = "rejected")]
        [JsonProperty("rejected")]
        [DefaultValue(false)]
        public string rejected { get; set; }

        [XmlAttributeAttribute(AttributeName = "scope")]
        [JsonProperty("scope")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SecureScope Scope { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "rlbOffice")]
        [JsonProperty(PropertyName = "rlbOffice")]
        public CodedType<int> RlbOffice { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "lastUpdated")]
        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated {get; set; }

        /// <summary>
        /// Serialisation based comparison. Whilst his will be really finicky - it would be equivalent
        /// to version control checks in github - which matchesd our use case.
        /// Otherwise, you could argue that ID is the main identity - but this is not true in our use case.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Exemplar other)
        {
            string otherData = JsonConvert.SerializeObject(other);
            string thisStr = JsonConvert.SerializeObject(this);
            return otherData.Equals(thisStr);
        }

        /// <summary>
        /// Gets the full depth of the classification
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetBuildingClassifications(string group)
        {
            var buildingClassifications = new Dictionary<string, string>();
            if (group == null)
            {
                var list = Groups.BuildingClassifications.ToList();
                if (list.Count > 0)
                {
                    buildingClassifications.Add(ExemplarConstants.RootClassification, list[0].Code );
                } else
                {
                    buildingClassifications.Add(ExemplarConstants.RootClassification, Exemplar.ComplexProjectKey);
                }
                buildingClassifications.Add(ExemplarConstants.SecondaryClassification, Exemplar.ComplexProjectKey);
                buildingClassifications.Add(ExemplarConstants.PrincipalClassification, Exemplar.ComplexProjectKey);
                return buildingClassifications;
            }
            
            var simplifiedGroup = group.Split(".");
            var depth = simplifiedGroup.Length;
            switch (depth)
            {
                case 1:
                    buildingClassifications.Add(ExemplarConstants.RootClassification, simplifiedGroup[0]);
                    buildingClassifications.Add(ExemplarConstants.SecondaryClassification, Exemplar.NotSetKey);
                    buildingClassifications.Add(ExemplarConstants.PrincipalClassification, Exemplar.NotSetKey);
                    break;
                case 2:
                    buildingClassifications.Add(ExemplarConstants.RootClassification, simplifiedGroup[0]);
                    buildingClassifications.Add(ExemplarConstants.SecondaryClassification, simplifiedGroup[0] + simplifiedGroup[1]);
                    buildingClassifications.Add(ExemplarConstants.PrincipalClassification, Exemplar.NotSetKey);
                    break;
                case 3:
                    buildingClassifications.Add(ExemplarConstants.RootClassification, simplifiedGroup[0]);
                    buildingClassifications.Add(ExemplarConstants.SecondaryClassification, simplifiedGroup[0] + simplifiedGroup[1]);
                    buildingClassifications.Add(ExemplarConstants.PrincipalClassification, simplifiedGroup[0] + simplifiedGroup[1] + simplifiedGroup[2]);
                    break;
            }
            return buildingClassifications;
        }

        /// <summary>
        /// Get ttoal cost for group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public decimal GetTotalCost(string group, bool isSingle = false)
        {
            if (Costs == null)
            {
                return 0;
            }
            if (Costs.TotalCost == null)
            {
                return 0;
            }
            if( group == null || isSingle)
            {
                return Costs.TotalCost.Value;
            }
            var items = Costs.CostItems.ToList();
            var maxItem = items.Aggregate((i1, i2) => {
                var val1 = GetGroupedScalarValue<decimal>(i1.Value, group);
                var val2 = GetGroupedScalarValue<decimal>(i2.Value, group);
                return val1 > val2 ? i1 : i2;
            });
            return GetGroupedScalarValue(maxItem.Value, group);
        }

        /// <summary>
        /// Get what we should consider the dominant code
        /// </summary>
        /// <param name="group"></param>
        /// <param name="countryCodeISO"></param>
        /// <returns></returns>
        public MeasurementVariable GetDominantMeasuredField(string group, string countryCodeISO, bool isSingle = false)
        {
            // This logic will actually be Per Office and Eventually Per Building Classification
            // Use total on Root
            if (group == null || isSingle)
            {
                if (Measurements.MaxFloorArea != null && Measurements.MaxFloorArea.MeasuredField != null)
                {
                    var variable = new MeasurementVariable(Measurements.MaxFloorArea.Value, Measurements.MaxFloorArea.MeasuredField);
                    variable.UnitOfMeasure = Measurements.MaxFloorArea.UnitOfMeasure;
                    if( variable.Value != default)
                    {
                       return variable;
                    }
                    
                }
            }
            var codes = ExemplarMeasurementMap.GetDominantVariablesForCountry(countryCodeISO);
            var selected = codes.FirstOrDefault(x => GetCodedMeasureAsMetric(group, x) != 0m);
            if( selected != default)
            {
                return new MeasurementVariable(GetCodedMeasureAsMetric(group, selected), selected);
            }
            var items = Measurements.Items.ToList();
            var maxItem = items.Aggregate((i1, i2) => {
                var val1 = GetGroupedScalarValue<decimal>(i1.Value, group);
                
                var val2 = GetGroupedScalarValue<decimal>(i2.Value, group);
                return val1 > val2 ? i1 : i2;
            });
            
            var result =  new MeasurementVariable(GetGroupedScalarValue<decimal>(maxItem.Value, group), maxItem.Code);
            result.UnitOfMeasure = maxItem.UnitOfMeasure;
            return result;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="Code"></param>
        /// <returns></returns>
        public decimal GetCodedMeasureAsMetric(string group, string Code)
        {
            var result = 0m;
            var unit = string.Empty;
            var groupedValue = Measurements.Items.FirstOrDefault((x) => x.Code.ToLower() == Code.ToLower());
            if (groupedValue != default)
            {
                result = GetGroupedScalarValue<decimal>(groupedValue.Value, group);
                unit = groupedValue.UnitOfMeasure;
            }
            if (result != 0m && unit != string.Empty)
            {
                if (MeasurementLookup.IsArea(unit) == MeasuredTypes.Conventional)
                {
                    result = MeasurementConversion.Area(false, true, result);
                }
            }

            return result;
        }    
       

        /// <summary>
        /// The first condition will faile.
        /// It should probably fail on Date validation
        /// </summary>
        /// <returns></returns>
        public int GetBaseDate()
        {
            if (Classification == null)
            {
                var seconds = (TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                return (int)seconds;
            }
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                //input.Classification.Date.Format not valid
                var date = DateTime.Now;
                if (Classification.Date.Value.Length == 8)
                {
                    date = DateTime.ParseExact(Classification.Date.Value, EightCharacterDateFormat, provider);
                }
                else
                {
                    date = DateTime.ParseExact(Classification.Date.Value, Classification.Date.Format, provider);
                }
                var seconds = (TimeZoneInfo.ConvertTimeToUtc(date) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                return (int)seconds;
            }
            catch
            {
                // Defaults to time added - not sure what else to do if our formatting data is invalid
                var seconds = (TimeZoneInfo.ConvertTimeToUtc(DateTime.Now) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                return (int)seconds;
            }
        }

        /// <summary>
        /// Helpers for getting values by group amd code
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="code"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public T getCodedValueForGroup<T>(FlatItem<GroupedValueModel<T>>[] input, string code, string group)
        {
            var found = SearchListByCode<GroupedValueModel<T>>(input, code);
            if (found != null)
            {
                return GetGroupedScalarValue<T>(found.Value, group);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Search function to find item in code
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public FlatItem<T> SearchListByCode<T>(FlatItem<T>[] input, string code)
        {
            if (input == null)
            {
                return null;
            }
            var listItems = input.ToList();
            var found = listItems.Find(x => x.Code.ToLower() == code.ToLower());
            return found;
        }

        /// <summary>
        /// Gets a single value from a list of grouped values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public T GetGroupedScalarValue<T>(GroupedValueModel<T>[] input, string group = null)
        {
            if (input == null)
            {
                return default(T);
            }
            var listItems = input.ToList();
            var found = listItems.Find(x => x.Group == group);
            if (found != null)
            {
                return found.Value;
            }
            // I think data may come both ways. Less than ideal.
            var attempt2 = listItems.Find(x => {
                if (x.Group != null)
                {
                    return x.Group.Replace(".", String.Empty) == group;
                }
                else
                {
                    return x.Group == group;
                }
            });
            if (attempt2 != null)
            {
                return attempt2.Value;
            }
            return default(T);
        }
        
        /// <summary>
        /// Consider this a single flat exemplar where only the Total Cost is relevant
        /// </summary>
        public void MapAsTotalCostOnly()
        {
            var costItems = new List<CostItem>();
            var totalCost = new CostItem()
            {
                Code = "1",
                Fieldname = "Total Construction Cost",
                ParameterType = "ICMS1",
                Type = "decimal",
                MappedId = TOTAL_COST_PARAMETER_ID,
                Value = null
            };
            var values = new List<GroupedValueModelWithZero<decimal>>();
            values.Add( new GroupedValueModelWithZero<decimal>()
            {
                Value = Costs.TotalCost.Value,
                ValueType = "decimal",
                Group = null                
            });
            var group = Groups.BuildingClassifications.FirstOrDefault();
            var leaf = GetLeaf(group);
            values.Add(new GroupedValueModelWithZero<decimal>()
            {
                Value = Costs.TotalCost.Value,
                ValueType = "decimal",
                Group = leaf.Code
            });
            totalCost.Value = values.ToArray();
            costItems.Add(totalCost);
            Costs.CostItems = costItems.ToArray();
            // Total cost would betray breakdowns from ROSS5D so this must be treated as standalone
            Classification.ShouldBreakIntoChildExemplars = false;
        }

        /// <summary>
        /// In this case no calculation is required... I think
        /// </summary>
        public void MapExistingICMSValuesOnly()
        {
            var icmsCosts = this.Costs.CostItems.Where(x => x.ParameterType.Contains("ICMS", StringComparison.InvariantCultureIgnoreCase)).ToArray();
            this.Costs.CostItems = icmsCosts;
        }
        
        public NestedCodedItem GetLeaf(NestedCodedItem group)
        {
            
            if (group.ChildClassification != null && group.ChildClassification.Length > 0)
            {
                // Ideally change the model to support this 
                return this.GetLeaf(group.ChildClassification[0]);
            }
            else
            {
                return group;
            }
        }
    }

}
