using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using abp.Authors;

namespace abp.Controllers.Authors
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Author")]
    [Route("api/app/authors")]
    public class AuthorController : AbpController, IAuthorAppService
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorsInput input)
        {
            return _authorAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AuthorDto> GetAsync(Guid id)
        {
            return _authorAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<AuthorDto> CreateAsync(AuthorCreateDto input)
        {
            return _authorAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AuthorDto> UpdateAsync(Guid id, AuthorUpdateDto input)
        {
            return _authorAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _authorAppService.DeleteAsync(id);
        }
    }
}