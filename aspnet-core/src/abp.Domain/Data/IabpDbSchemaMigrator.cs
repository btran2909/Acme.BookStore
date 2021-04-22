using System.Threading.Tasks;

namespace abp.Data
{
    public interface IabpDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}