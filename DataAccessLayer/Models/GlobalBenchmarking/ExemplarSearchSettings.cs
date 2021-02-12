using Newtonsoft.Json;
using RLBPulse.GlobalBenchmarking.Filters;
using RLBPulse.GlobalBenchmarking.Mapping;
using System;
using System.Collections.Generic;

namespace RLBPulse.GlobalBenchmarking.Models
{
    public interface HasEscalationInput<numericType, stringType>
    {
        [JsonProperty(PropertyName = "escalationMonth")]
        numericType EscalationMonth { get; set; }

        [JsonProperty(PropertyName = "escalationYear")]
        numericType EscalationYear { get; set; }
        

        [JsonProperty(PropertyName = "relativeCity")]
        stringType RelativeCity { get; set; }
    }
    public class EscalationInput<numericType, stringType> : HasEscalationInput<numericType, stringType>
    {
        [JsonProperty(PropertyName = "escalationMonth", NullValueHandling = NullValueHandling.Ignore)]
        public numericType EscalationMonth { get; set; }

        [JsonProperty(PropertyName = "escalationYear", NullValueHandling = NullValueHandling.Ignore)]
        public numericType EscalationYear { get; set; }
       

        [JsonProperty(PropertyName = "relativeCity", NullValueHandling = NullValueHandling.Ignore)]
        public stringType RelativeCity { get; set; }

        [JsonProperty(PropertyName = "escalationType")]
        public int EscalationType { get; set; }
    }

    public class ExemplarSearchSettings
    {
        [JsonProperty(PropertyName = "measurementVariableId")]
        public Guid MeasurementVariableId { get; set; }

        [JsonProperty(PropertyName = "measurementVariableCode")]
        public string MeasurementVariableCode { get; set; }

        [JsonProperty(PropertyName = "useMetric")]
        public bool UseMetric { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "escalation")]
        public EscalationInput<int, string> Escalation { get; set; }
        
        [JsonProperty(PropertyName = "EntireProjectOnly")]
        public bool ShowComplexProjectsOnly { get; set; }

        [JsonProperty(PropertyName = "TotalResults")]
        public int? TotalResults { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        // 
        // 
        /// <summary>
        /// This should be defined per user based on the city of their office however If the user is in the Global organisation group
        /// that is no longer predictable. Ideally this is set in the user profile instead of OrgGroup. We use this so we can always run a single query
        /// which makes it easier to perform in emmory cache.
        /// </summary>        
        //private readonly Guid BASE_RELATIVE_CITY = new Guid("DC6EC044-FFB4-4974-80E2-A04E1EDB8F1D"); Did not realise the GUIDS would change...
        private readonly Guid BASE_RELATIVE_CITY = new Guid("BFA49EA5-4478-4A55-A26E-693436CDC0C6");

        public ExemplarSearchSettings()
        {
            this.SetDefaults();
        }

        public void SetDefaults()
        {
            Escalation = new EscalationInput<int, string>();
            if (Escalation.EscalationType == SupportedEscalations.NONE)
            {
                var date = DateTime.Now;
                Escalation.EscalationMonth = date.Month;
                Escalation.EscalationYear = date.Year;
            }
            if (Escalation.EscalationType != SupportedEscalations.ESCALATIONandRELATIVITY)
            {
                Escalation.RelativeCity = BASE_RELATIVE_CITY.ToString();
            }
        }
    }

    public class AvailableEscalatedCities
    {
        public string Label { get; set; }
        public Guid Id { get; set; }
        
        public string MaxDate { get; set; }
        
        public string MinDate { get; set; }

        public string Currency { get; set; }
    }

    public class AvailableVariables
    {
        public string Label { get; set; }
        public Guid Id { get; set; }

        public string MeasuredUnit { get; set; }
        
        public int MeasuredType{ get; set; }

        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }
        
    }

    // this is just a type!
    public class ExemplarFormSettings 
    {
        public AvailableEscalatedCities[] EscalationCities { get; set; }
        public List<SelectableValue<string>> AvailableCurrencies { get; set; }

        public List<AvailableVariables> AvailableVariables{ get; set; }

        public List<SelectableValue<string>> RootClassifications{ get; set; }

        public List<SelectableValue<string>> SecondaryClassifications { get; set; }

        public List<SelectableValue<string>> TeritaryClassifications { get; set; }

        public List<SelectableValue<string>> Countries { get; set; }

        public List<SelectableValue<string>> Cities { get; set; }

        public List<SelectableValue<int>> Offices { get; set; }

        // Get All Building Classes Maybe?
    }

    public class ExemplarSearchRefinements
    {
        [JsonProperty(PropertyName = "qualifications")]
        public ExemplarQualificationFilterModel Qualifications { get; set; }

        [JsonProperty(PropertyName = "functionalUnits")]
        public VariableFilterModel Variables { get; set; }
    }

    public class ExemplarSearchProtocol
    {
        [JsonProperty(PropertyName = "settings")]
        public ExemplarSearchSettings Settings {get; set;}

        [JsonProperty(PropertyName = "query")]
        public ExemplarIndexFilterModel Query { get; set; }

        [JsonProperty(PropertyName = "refinements")]
        public ExemplarSearchRefinements Refinements { get; set; }
    }
}
