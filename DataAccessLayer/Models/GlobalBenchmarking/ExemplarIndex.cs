using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RLBPulse.GlobalBenchmarking.Security;
using RLBPulse.GlobalBenchmarking.MonadicQuery;
using Dapper.Contrib.Extensions;

/**
* This is our map reduce equivalent idea
 */

namespace RLBPulse.GlobalBenchmarking.Models
{
    
    /// <summary>
    /// This is effectively the type that is used for filters and filtering
    /// Anything in this calss can be filtered.
    /// Values are stored in Exempalr Reduction
    /// </summary>
    /// <typeparam name="StringResultType"></typeparam>
    /// <typeparam name="NumericResultType"></typeparam>
    /// <typeparam name="DiscreteNumericType"></typeparam>
    [SerializableAttribute()]
    public class ExemplarIndex<StringResultType, NumericResultType, DiscreteNumericType>            
    {
        
        // Measurements
        [JsonProperty(PropertyName = "maxSize")]
        public NumericResultType DominantArea { get; set; }

        [JsonProperty(PropertyName = "IPMS1")]
        public NumericResultType IPMS1 { get; set; }

        [JsonProperty(PropertyName = "IPMS2")]
        public NumericResultType IPMS2 { get; set; }

        // A qualifer but as such should be global
        [JsonProperty(PropertyName = "Storeys")]
        public NumericResultType Storeys { get; set; }

        // Costs
        [JsonProperty(PropertyName = "totalCost")]
        public NumericResultType TotalCost { get; set; }

        [Computed]
        [JsonProperty(PropertyName = "EscalatedCost")]
        public NumericResultType EscalatedCost { get; set; }

        [Computed]
        [JsonProperty(PropertyName = "EscalatedCostPerUnitMeasured")]
        public NumericResultType EscalatedCostPerUnitMeasured { get; set; }


        // Building Classes
        [JsonProperty(PropertyName = "RootClassification")]
        public StringResultType RootClassification { get; set; }

        [JsonProperty(PropertyName = "SecondaryClassification")]
        public StringResultType SecondaryClassification { get; set; }

        // This is not actually the tertiary classification - it is the group that matches costs 
        [JsonProperty(PropertyName = "PrincipalClassification")]
        public StringResultType PrincipalClassification { get; set; }
        

        // Locations
        [JsonProperty(PropertyName = "Country")]
        public StringResultType Country { get; set; }

        [JsonProperty(PropertyName = "City")]
        public StringResultType City { get; set; }

        [JsonProperty(PropertyName = "Office")]
        public DiscreteNumericType Office { get; set; }


        // Qualifications
        [JsonProperty(PropertyName = "Date")]
        public DiscreteNumericType Date { get; set; }

        // Measures
        [Computed]
        [JsonProperty(PropertyName = "MeasuredVariableValue")]
        public NumericResultType MeasuredVariableValue { get; set; }

    }

}
