using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Test.Pro.AuthorPros;

namespace Volo.Test.Pro.Samples
{
    public class SampleAppService : ProAppService, ISampleAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public SampleAppService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<SampleDto> GetAsync(GetAuthorsInput input)
        {
            var totalCount = await _authorRepository.GetCountAsync(input.FilterText, input.NameSurname, input.AgeMin, input.AgeMax);
            var items = await _authorRepository.GetListAsync(input.FilterText, input.NameSurname, input.AgeMin, input.AgeMax, input.Sorting, input.MaxResultCount, input.SkipCount);
            return await Task.FromResult(
                new SampleDto
                {
                    TotalCount = totalCount,
                    Items = items
                }
            );
        }

        [Authorize]
        public Task<SampleDto> GetAuthorizedAsync(GetAuthorsInput input)
        {
            return Task.FromResult(
                new SampleDto
                {
                    TotalCount = 42
                }
            );
        }
    }
}