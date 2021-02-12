using Dapper.Contrib.Extensions;
using System;
// ReSharper disable InconsistentNaming - ID is the name format in the database
// ReSharper disable UnusedMember.Global - Dapper sees members via reflection

namespace RLBPulse.StandardParameters.DAL.Entities
{
    [Table("StandardParameterMapping")]
    public class StandardParameterMappingEntity
    {
        [Computed]
        public Guid StdParameterTypeIDFrom { get; set; }

        [Computed]
        public Guid StdParameterTypeIDTo { get; set; }
        public Guid StdParameterIDFrom { get; set; }

        public Guid StdParameterIDTo { get; set; }
        public Guid MapId { get; set; }
    }


}
