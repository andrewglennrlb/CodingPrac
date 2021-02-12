using Dapper.Contrib.Extensions;
using System;
// ReSharper disable InconsistentNaming - ID is the name format in the database
// ReSharper disable UnusedMember.Global - Dapper sees members via reflection

namespace RLBPulse.StandardParameters.DAL.Entities
{
    [Table("StandardVariable")]
    public class StandardParameterEntity
    {
        [ExplicitKey]
        public Guid StdParameterID { get; set; }
        public Guid StdParameterTypeID { get; set; }
        public Guid ParentStdParameterID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Seq { get; set; }

        public override string ToString()
        {
            return $"StdParam {Code}";
        }
    }

}
