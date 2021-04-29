﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Test.Pro.AuthorPros;

namespace Volo.Test.Pro.EntityFrameworkCore
{
    [DependsOn(
        typeof(ProDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ProEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ProDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Author, EfCoreAuthorRepository>();
            });
        }
    }
}