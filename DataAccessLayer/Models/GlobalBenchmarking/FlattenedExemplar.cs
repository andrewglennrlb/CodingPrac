using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RLBPulse.GlobalBenchmarking.Document;
using System.Runtime.Serialization;
using RLBPulse.GlobalBenchmarking.Mapping;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using RLBPulse.GlobalBenchmarking.Measurement;
using RLBPulse.GlobalBenchmarking.DatabaseModels;

namespace RLBPulse.GlobalBenchmarking.Models
{
   
    [SerializableAttribute()]
    public class FriendlyValue {
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "FieldName")]
        [JsonProperty(PropertyName = "FieldName")]
        public string FieldName{ get; set;}

        [XmlTextAttribute]
        [JsonProperty(PropertyName = "Value")]
        public decimal Value{ get; set;}
    }
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", ElementName = "exemplar", IsNullable = false)]
    [KnownType(typeof(RLBPulse.GlobalBenchmarking.Models.FlattenedExemplar))]
    public class FlattenedExemplar : ExemplarReducer, IEquatable<FlattenedExemplar>, IDocument<int>
    {
        [XmlAttributeAttribute(AttributeName = "documentType")]
        [JsonProperty("documentType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SupportedDocuments DocumentType { get; set; }

        [JsonProperty(PropertyName = "RlbOffice")]
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "RlbOffice")]
        public CodedType<int> RlbOffice { get; set; }

        [XmlElement("costs")]
        [JsonProperty(PropertyName = "costs")]
        public XmlCapableDictionary Costs{ get; set;}

        [XmlElement("areas")]
        [JsonProperty(PropertyName = "areas")]
        public XmlCapableDictionary Areas{ get; set;}

        [XmlElement("volumes")]
        [JsonProperty(PropertyName = "volumes")]
        public XmlCapableDictionary Volumes{ get; set;}

        [XmlElement("qualifiers")]
        [JsonProperty(PropertyName = "qualifiers")]
        public Qualification Qualifiers { get; set; }

        [XmlElement("dimensions")]
        [JsonProperty(PropertyName = "dimensions")]
        public XmlCapableDictionary Dimensions{ get; set;}
        // The problem with dictionary is that we will need to write a custom serialiser
        // for XML - even though JSON support is especially good.
        // We can get into a mess with Sparse Data set support as well.
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "functionalUnits")]
        [JsonProperty(PropertyName = "functionalUnits")]
        public XmlCapableDictionary FunctionalUnits{ get; set;}        

        public FlattenedExemplar() : base() {

        }
        public FlattenedExemplar(Exemplar input, int Id, string group = null ) : base(input, group) {

            this.Id = Id;
            this.RlbOffice = input.RlbOffice;
            this.IsClassified = input.Classification.IsClassified;
            this.IsAnonymous = input.Classification.IsAnonymous;
            this.DocumentType = SupportedDocuments.ExemplarApprovedGlobal;
            this.Costs = this.FlattenCosts( input.Costs.CostItems, group, "ICMS1-" + this.Currency, input);
            this.Areas = this.FlattenItems( input.Measurements.Items, group, MeasurementLookup.IsArea, this.Uom ? "M2" :  "SF", input);
            this.Dimensions = this.FlattenItems( input.Measurements.Items, group, MeasurementLookup.IsDimension, this.Uom ? "M2" : "SF", input);
            this.Volumes = this.FlattenItems( input.Measurements.Items, group, MeasurementLookup.IsVolume, this.Uom ? "M2" : "SF", input);
            this.FunctionalUnits = this.FlattenItems( input.Measurements.FunctionalUnits,group, MeasurementLookup.IsFunctionalUnit, this.Uom ? "M2" : "SF", input);

        }
        public FlattenedExemplar(FlattenedExemplar other, bool toMetric, string outputCurrency = "") {

            this.Id = other.Id;

            // For Indexing Work
            this.FillFromReducedModel(other);
            this.Costs = other.Costs;
            this.Areas = this.ConvertDictionary( toMetric, other.Uom, other.Areas, MeasurementConversion.Area, other.Uom ? "M2" :  "FT2");
            this.Dimensions = this.ConvertDictionary( toMetric, other.Uom, other.Dimensions, MeasurementConversion.Dimension, other.Uom ? "M" :  "FT");
            this.Volumes = this.ConvertDictionary( toMetric, other.Uom, other.Volumes, MeasurementConversion.Volume, other.Uom ? "M3" :  "FT3");
            this.FunctionalUnits = other.FunctionalUnits;
            this.Currency = (outputCurrency == "" || outputCurrency == "undefined") ? other.Currency : outputCurrency;
            this.Costs.Prefix ="ICMS1";
            this.Variables = other.Variables;
        }
        private void FillFromReducedModel(ExemplarReducer other)
        {
            this.BaseIndex = other.BaseIndex;
            this.City = other.City;
            this.ClassificationName = other.ClassificationName;
            this.Country = other.Country;
            this.Currency = other.Currency;
            this.Date = other.Date;
            this.DominantArea = other.DominantArea;
            this.DominantMeasuredArea = other.DominantMeasuredArea;
            this.EscalatedCost = other.EscalatedCost;
            this.EscalatedCostPerUnitMeasured = other.EscalatedCostPerUnitMeasured;
            this.EscalationIndex = other.EscalationIndex;
            this.ExchangeRate = other.ExchangeRate;
            this.ForwardIndex = other.ForwardIndex;
            this.Id = other.Id;
            this.IPMS1 = other.IPMS1;
            this.IPMS2 = other.IPMS2;
            this.IsAnonymous = other.IsAnonymous;
            this.IsClassified = other.IsClassified;
            this.Location = other.Location;
            this.LocationAdjustment = other.LocationAdjustment;
            this.MeasuredType = other.MeasuredType;
            this.MeasuredVariableValue = other.MeasuredVariableValue;
            this.OfficeName = other.OfficeName;
            this.ParentIndexId = other.ParentIndexId;
            this.PrincipalClassification = other.PrincipalClassification;
            this.RelativeCityIndex = other.RelativeCityIndex;
            this.RelativityIndex = other.RelativityIndex;
            this.RootClassification = other.RootClassification;
            this.SecondaryClassification = other.SecondaryClassification;
            this.Storeys = other.Storeys;
            this.Title = other.Title;
            this.TotalCost = other.TotalCost;
            this.Uom = other.Uom;
            DominantMeasureUnit = other.DominantMeasureUnit;
            this.SecureAndAnomylise();
        }
        public new void SecureAndAnomylise()
        {
            if (IsAnonymous)
            {
                Title = ANON_HEADING_PREFIX + Id.ToString();
            }
            if (Qualifications != default)
            {
                Qualifications.Client = ANON_HEADING_PREFIX + "CLIENT";
            }
            if( Qualifiers != default)
            {
                Qualifiers.Client = ANON_HEADING_PREFIX + "CLIENT";
            }
        }
        public FlattenedExemplar(ExemplarReducer other )
        {
            this.FillFromReducedModel(other);
            // For Indexing Work

        }
        private XmlCapableDictionary ConvertDictionary(bool toMetric, bool isMetric, XmlCapableDictionary dictionary, Converter unitConversion, string prefix) {
            var result = new XmlCapableDictionary();
            result.Prefix = prefix; 
            if( dictionary == default)
            {
                return null;
            }
            dictionary.ToList().ForEach( x => {
                result.Add( x.Key, new FriendlyValue() { FieldName = x.Value.FieldName, Value = unitConversion( isMetric, toMetric, x.Value.Value) } );
            });
            return result;
        }
        public XmlCapableDictionary FlattenCosts(FlatItem<GroupedValueModelWithZero<decimal>>[] items, string group, string prefix, Exemplar input) {
            var result = new XmlCapableDictionary();
            if (items == null)
            {
                return result;
            }
            result.Prefix = prefix; 
            
            for( var i=0; i < items.Length; i++ ) {
                var value = input.GetGroupedScalarValue<decimal>(items[i].Value, group);
                result.TryAdd( items[i].Code, new FriendlyValue() { Value = value, FieldName = items[i].Fieldname  } );
            }
            return result;
        }

         // Not sure how to reuse this between models - arguably we simplify items to support both types.
         public XmlCapableDictionary FlattenItems(MeasuredItem<GroupedValueModel<decimal>>[] items, string group, IsUnitType uomCheck, string prefix, Exemplar input) {
            var result = new XmlCapableDictionary();
            if( items == null)
            {
                return result;
            }
            result.Prefix = prefix; 
            for( var i=0; i < items.Length; i++ ) {
                if( uomCheck( items[i].UnitOfMeasure ) != MeasuredTypes.NotFound ) {
                    var value = input.GetGroupedScalarValue<decimal>(items[i].Value, group);
                    result.TryAdd( items[i].Code, new FriendlyValue() { Value = value, FieldName = items[i].Fieldname  } );
                }                
            }
            return result;
        }        
        // Should be a Code
        // Option 1: Map ICSMS entirely to costs values
        // Option 2: Just go with a dictionary
        public bool Equals(FlattenedExemplar other)
        {
            throw new NotImplementedException();
        }
    }

    [SerializableAttribute()]
    public class XmlCapableDictionary : Dictionary<string, FriendlyValue>, IXmlSerializable
    {
        public string Prefix{ get; set;}
        public XmlCapableDictionary() {
        }
        public XmlSchema GetSchema()
        {
            return null;
        }

        // Unlikely to read an XML input - json to xml mainly - note this will not work as looped yet
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
	        var elements = reader.ReadElementContentAsDecimal().AsDictionary();
            elements.Keys.ToList().ForEach( key => {
                this.Add( key, (FriendlyValue)elements[key]);
            });
        }
        private string CleanTitle(string code, string name) {
            code = code.Trim();
            name = name.Trim();
             if( this.Prefix == null) {
                this.Prefix = "F";
            }
             string cleanedTitle = Regex.Replace(name, "[^A-Za-z]+", "-");
             return string.Format("{0}-{1}_{2}", this.Prefix, cleanedTitle, code);
        }
        public void WriteXml(XmlWriter writer)
        {
            
            // XElement xElem = new XElement(this._element,
            //                    this.Select(x=>new XElement(x.Key,x.Value)));
            var items = this.Select(x=>new XElement(
                this.CleanTitle(x.Key, x.Value.FieldName),
                x.Value.Value));
            foreach(var item in items) {
                item.WriteTo(writer);
            }
            
            // string xml = xElem.WriteTo(writer); //xElem.Save(.....);
            // writer.WriteString( xElem );
            // writer.WriteElementString(xml)
        }
    }
}