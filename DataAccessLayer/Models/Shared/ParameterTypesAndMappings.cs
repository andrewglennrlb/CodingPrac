using System.Collections.Generic;

namespace RLBPulse.StandardParameters.DAL.Entities
{
    /// <summary>
    /// Contains all standard parameter types, parameters and mappings.
    /// </summary>
    public class ParameterTypesAndMappings
    {
        public IEnumerable<StandardParameterTypeEntity> StandardParameterTypes { get; }
        public IEnumerable<StandardParameterMappingEntity> Mappings { get; }

        public ParameterTypesAndMappings(IEnumerable<StandardParameterTypeEntity> standardParameterTypes,
                IEnumerable<StandardParameterMappingEntity> mappings)
        {
            StandardParameterTypes = standardParameterTypes;
            Mappings = mappings;
        }
    }


}
