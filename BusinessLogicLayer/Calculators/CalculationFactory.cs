using DAL.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Calculators
{
    public class CalculationFactory
    {
        public static decimal Calculate(IEnumerable<ICalculationObject> calculations)
        {
           decimal accumulation = 0m;
            foreach (var item in calculations) {
                if( item.IncludeInCalculation() )
                {
                    switch (item.CalculationType)
                    {
                        case CalculationTypes.Cascading:
                            accumulation += CalculationFactory.Calculate(item.Calculations);
                            break;
                        case CalculationTypes.formulaic:
                            accumulation += item.CalculateFormula();
                            break;
                        case CalculationTypes.Partial:
                            accumulation += (decimal)item.PartialContribution * item.CalculationAmount;
                            break;
                        case CalculationTypes.linear:
                            accumulation += item.CalculationAmount;
                            break;
                        default:
                            accumulation += item.CalculationAmount;
                            break;
                    }
                }
                
            }
            return accumulation;
        }
    }
}
