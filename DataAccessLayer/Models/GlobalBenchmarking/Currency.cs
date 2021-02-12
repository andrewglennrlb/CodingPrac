using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RLBPulse.GlobalBenchmarking.Models
{
    
    [SerializableAttribute()]
    public class Currency : CodedType<Decimal>, IHasSymbol 
    {
        [XmlAttributeAttribute(AttributeName = "symbol")]
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }
    public class ExchangeRate {
        public string OutputCode {get; set; }
        public decimal BuyingRate {get; set; }
    }
    [SerializableAttribute()]
    public class AvailableCurrencies : BaseSearchableSet
    {
      
        [JsonProperty(PropertyName = "AvailableRates")]
        public List<ExchangeRate> AvailableRates { get; set; }
              
    }
}
