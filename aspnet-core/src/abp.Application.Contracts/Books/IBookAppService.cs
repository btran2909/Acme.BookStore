using abp.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace abp.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task<PagedResultDto<BookWithNavigationPropertiesDto>> GetListAsync(GetBooksInput input);

        Task<BookWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<BookDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid?>>> GetAuthorLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<BookDto> CreateAsync(BookCreateDto input);

        Task<BookDto> UpdateAsync(Guid id, BookUpdateDto input);
    }
}