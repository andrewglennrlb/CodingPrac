using System;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming - ID is the name format in the database
// ReSharper disable UnusedMember.Global - Dapper sees members via reflection

namespace RLBPulse.StandardParameters.DAL.Entities
{
    public class StandardParameterTypeEntity
    {
        public Guid StdParameterTypeID { get; set; }
        public Guid ParentStdParameterTypeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Seq { get; set; }
        public List<StandardParameterEntity> StandardParameters { get; } = new List<StandardParameterEntity>();

        internal void AddStandardParameter(StandardParameterEntity sp)
        {
            StandardParameters.Add(sp);
        }

        public override string ToString()
        {
            return $"StdParamType: {Code} {Description}";
        }
    }
}
