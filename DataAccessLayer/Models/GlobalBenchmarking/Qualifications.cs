using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface ISecurableQualifications
    {
        bool IsClassified { get; set; }

        bool IsAnonymous { get; set; }
    }
    public interface IQualification<numericType, dateType, stringType>
    {
        stringType CostStage
        {
            get; set;
        }
        // Total, Elemental Grouped Elemental
        stringType CostType { get; set; }

        stringType WorkType { get; set; }

        numericType LocationAdjustment { get; set; }

        stringType Description { get; set; }

        stringType ServiceProvided { get; set; }

        dateType ProgramStartDate { get; set; }

        dateType ProgramEndDate { get; set; }

        stringType Client { get; set; }

        stringType ProcurementRoute { get; set; }

        stringType GreenRating { get; set; }

        numericType Storeys { get; set; }

        dateType DurationInWeeks { get; set; }        

    }
    [SerializableAttribute()]
    public class Qualification : IQualification<decimal, int, string>, ISecurableQualifications
    {
        
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "costStage")]
        [JsonProperty(PropertyName = "costStage")]
        public string CostStage
        {
            get; set;
        }
        // Total, Elemental Grouped Elemental
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "costType")]
        [JsonProperty(PropertyName = "costType")]
        public string CostType { get; set; }

        //  new build, refurbishment
        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "workType")]
        [JsonProperty(PropertyName = "workType")]
        public string WorkType { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "locationAdjuster")]
        [JsonProperty(PropertyName = "locationAdjuster")]
        public decimal LocationAdjustment { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "description")]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "serviceProvided")]
        [JsonProperty(PropertyName = "serviceProvided")]
        public string ServiceProvided { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "programStartDate")]
        [JsonProperty(PropertyName = "programStartDate")]
        public int ProgramStartDate { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "programEndDate")]
        [JsonProperty(PropertyName = "programEndDate")]
        public int ProgramEndDate { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "client")]
        [JsonProperty(PropertyName = "client")]
        public string Client { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "procurementRoute")]
        [JsonProperty(PropertyName = "procurementRoute")]
        public string ProcurementRoute { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "greenRating")]
        [JsonProperty(PropertyName = "greenRating")]
        public string GreenRating { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "storeys")]
        [JsonProperty(PropertyName = "storeys")]
        public decimal Storeys { get; set; }

        [XmlElementAttribute(Form = XmlSchemaForm.Unqualified, ElementName = "durationInWeeks")]
        [JsonProperty(PropertyName = "durationInWeeks")]
        public int DurationInWeeks { get; set; }

        [XmlElementAttribute("isClassified")]
        [JsonProperty(PropertyName = "isClassified")]
        public bool IsClassified { get; set; }

        [XmlElementAttribute("isAnonymous")]
        [JsonProperty(PropertyName = "isAnonymous")]
        public bool IsAnonymous { get; set; }

        [XmlElementAttribute("ShouldBreakIntoChildExemplars")]
        [JsonProperty(PropertyName = "ShouldBreakIntoChildExemplars")]
        public bool ShouldBreakIntoChildExemplars { get; set; }

        [Dapper.Contrib.Extensions.Computed]
        [XmlElementAttribute("ComplexProject")]
        [JsonProperty(PropertyName = "ComplexProject", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ComplexProject { get; set; }

        [XmlElementAttribute("notableInclusions")]
        [JsonProperty(PropertyName = "notableInclusions")]
        public string NotableInclusions { get; set; }

        [XmlElementAttribute("notableExclusions")]
        [JsonProperty(PropertyName = "notableExclusions")]
        public string NotableExclusions { get; set; }

      
        public void fillFromQualification(Qualification other)
        {
            this.Client = other.Client;
            this.ComplexProject = other.ComplexProject;
            this.CostStage = other.CostStage;
            this.CostType = other.CostType;
            this.Description = other.Description;
            this.DurationInWeeks = other.DurationInWeeks;
            this.GreenRating = other.GreenRating;
            
            this.IsAnonymous = other.IsAnonymous;
            this.IsClassified = other.IsClassified;
            this.LocationAdjustment = other.LocationAdjustment;
            this.NotableExclusions = other.NotableExclusions;
            this.NotableInclusions = other.NotableInclusions;
            this.ProcurementRoute = other.ProcurementRoute;
            
            this.ProgramEndDate = other.ProgramEndDate;
            this.ProgramStartDate = other.ProgramStartDate;
            this.ServiceProvided = other.ServiceProvided;
            
            this.ShouldBreakIntoChildExemplars = other.ShouldBreakIntoChildExemplars;
            this.Storeys = other.Storeys;
            this.WorkType = other.WorkType;

        }
        public Qualification ShallowCopy()
        {
            return (Qualification)this.MemberwiseClone();
        }
    }

}