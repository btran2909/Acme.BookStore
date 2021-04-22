using abp.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using abp.Books;

namespace abp.Controllers.Books
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Book")]
    [Route("api/app/books")]
    public class BookController : AbpController, IBookAppService
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<BookWithNavigationPropertiesDto>> GetListAsync(GetBooksInput input)
        {
            return _bookAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<BookWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _bookAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<BookDto> GetAsync(Guid id)
        {
            return _bookAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("author-lookup")]
        public Task<PagedResultDto<LookupDto<Guid?>>> GetAuthorLookupAsync(LookupRequestDto input)
        {
            return _bookAppService.GetAuthorLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<BookDto> CreateAsync(BookCreateDto input)
        {
            return _bookAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<BookDto> UpdateAsync(Guid id, BookUpdateDto input)
        {
            return _bookAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _bookAppService.DeleteAsync(id);
        }
    }
}