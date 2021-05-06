using System.Collections.Generic;

namespace Volo.Test.Pro.ExternalProviders
{
    public class ExternalProviderDefinition
    {
        public string Name { get; set; }

        public List<ExternalProviderDefinitionProperty> Properties { get; set; }

        public ExternalProviderDefinition()
        {
            Properties = new List<ExternalProviderDefinitionProperty>();
        }
    }
}
