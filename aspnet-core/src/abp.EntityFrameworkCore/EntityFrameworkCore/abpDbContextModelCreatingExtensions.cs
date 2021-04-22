using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace abp.EntityFrameworkCore
{
    public static class abpDbContextModelCreatingExtensions
    {
        public static void Configureabp(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(abpConsts.DbTablePrefix + "YourEntities", abpConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}