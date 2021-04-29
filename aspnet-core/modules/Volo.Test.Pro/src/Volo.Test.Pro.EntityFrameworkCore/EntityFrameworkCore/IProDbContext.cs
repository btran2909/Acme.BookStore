﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Test.Pro.AuthorPros;

namespace Volo.Test.Pro.EntityFrameworkCore
{
    [ConnectionStringName(ProDbProperties.ConnectionStringName)]
    public interface IProDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Author> Authors { get; }
    }
}