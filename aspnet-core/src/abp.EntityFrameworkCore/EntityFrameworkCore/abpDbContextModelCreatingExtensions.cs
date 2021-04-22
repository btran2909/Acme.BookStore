using abp.Books;
using Volo.Abp.EntityFrameworkCore.Modeling;
using abp.Authors;
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

            builder.Entity<Author>(b =>
            {
                b.ToTable(abpConsts.DbTablePrefix + "Authors", abpConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.NameSurname).HasColumnName(nameof(Author.NameSurname));
                b.Property(x => x.Age).HasColumnName(nameof(Author.Age));
            });

            builder.Entity<Book>(b =>
            {
                b.ToTable(abpConsts.DbTablePrefix + "Books", abpConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Title).HasColumnName(nameof(Book.Title));
                b.Property(x => x.Year).HasColumnName(nameof(Book.Year));
            });
        }
    }
}