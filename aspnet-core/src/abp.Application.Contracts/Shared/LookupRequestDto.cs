using Volo.Abp.Application.Dtos;

namespace abp.Shared
{
    public class LookupRequestDto : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}