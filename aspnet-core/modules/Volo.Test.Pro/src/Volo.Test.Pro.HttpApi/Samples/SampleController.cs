using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Test.Pro.AuthorPros;

namespace Volo.Test.Pro.Samples
{
    [RemoteService]
    [Route("api/Pro/sample")]
    public class SampleController : ProController, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }

        [HttpGet]
        public async Task<SampleDto> GetAsync(GetAuthorsInput input)
        {
            return await _sampleAppService.GetAsync(input);
        }

        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<SampleDto> GetAuthorizedAsync(GetAuthorsInput input)
        {
            return await _sampleAppService.GetAsync(input);
        }
    }
}
