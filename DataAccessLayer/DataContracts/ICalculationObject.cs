using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContracts
{
    public enum CalculationTypes
    {
        linear = 1,
        formulaic = 2,
        Cascading = 3,
        Partial = 4
    }
    
    public interface ICalculationObject
    {
        decimal CalculationAmount { get; set; }

        decimal? PartialContribution { get; set; }

        bool IncludeInCalculation();

        decimal CalculateFormula();

        CalculationTypes CalculationType { get; set; }

        List<ICalculationObject> Calculations { get; set; }
    }
}
