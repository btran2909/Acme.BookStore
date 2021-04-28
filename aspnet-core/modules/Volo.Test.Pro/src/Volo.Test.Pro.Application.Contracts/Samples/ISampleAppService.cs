using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Volo.Test.Pro.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
