using System;
using Volo.Abp;

namespace Volo.Test.Pro.ExternalProviders
{
    [Serializable]
    public class ExternalProviderSettingsProperty : NameValue<string>
    {
        public ExternalProviderSettingsProperty()
        {

        }

        public ExternalProviderSettingsProperty(string name, string value)
            : base(name, value)
        {

        }
    }
}
