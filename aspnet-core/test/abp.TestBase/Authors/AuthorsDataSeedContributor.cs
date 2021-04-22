using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using abp.Authors;

namespace abp.Authors
{
    public class AuthorsDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsDataSeedContributor(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _authorRepository.InsertAsync(new Author
            (
                id: Guid.Parse("dff432a6-0a34-4613-a95c-fa21ce98dde0"),
                nameSurname: "e8bd27b7dac648c48e438cc",
                age: 646693126
            ));

            await _authorRepository.InsertAsync(new Author
            (
                id: Guid.Parse("301107d4-4194-4966-8521-f764e8c0a39e"),
                nameSurname: "12a09b63946e4be4b49e481dbdde58d9a99907be36ca41a2990c403ddb8e7d89d64666c9197b40359",
                age: 1299340024
            ));
        }
    }
}