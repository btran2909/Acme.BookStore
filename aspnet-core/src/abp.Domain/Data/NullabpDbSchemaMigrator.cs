using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace abp.Data
{
    /* This is used if database provider does't define
     * IabpDbSchemaMigrator implementation.
     */
    public class NullabpDbSchemaMigrator : IabpDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}