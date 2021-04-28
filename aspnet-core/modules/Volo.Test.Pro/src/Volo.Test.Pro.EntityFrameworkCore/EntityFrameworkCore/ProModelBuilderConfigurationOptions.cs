using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Test.Pro.EntityFrameworkCore
{
    public class ProModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ProModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}