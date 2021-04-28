using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Test.Pro.EntityFrameworkCore
{
    [ConnectionStringName(ProDbProperties.ConnectionStringName)]
    public class ProDbContext : AbpDbContext<ProDbContext>, IProDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public ProDbContext(DbContextOptions<ProDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePro();
        }
    }
}