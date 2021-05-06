using System.Collections.Generic;

namespace Volo.Test.Pro.ExternalProviders
{
    public class AbpExternalProviderOptions
    {
        public List<ExternalProviderDefinition> Definitions { get; set; }

        public AbpExternalProviderOptions()
        {
            Definitions = new List<ExternalProviderDefinition>();
        }
    }
}
