using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Test.Pro.AuthorPros;

namespace Volo.Test.Pro.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync(GetAuthorsInput input);

        Task<SampleDto> GetAuthorizedAsync(GetAuthorsInput input);
    }
}
