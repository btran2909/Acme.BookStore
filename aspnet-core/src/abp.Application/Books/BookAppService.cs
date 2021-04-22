using abp.Shared;
using abp.Authors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using abp.Permissions;
using abp.Books;

namespace abp.Books
{
    [RemoteService(IsEnabled = false)]
    [Authorize(abpPermissions.Books.Default)]
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;

        public BookAppService(IBookRepository bookRepository, IRepository<Author, Guid> authorRepository)
        {
            _bookRepository = bookRepository; _authorRepository = authorRepository;
        }

        public virtual async Task<PagedResultDto<BookWithNavigationPropertiesDto>> GetListAsync(GetBooksInput input)
        {
            var totalCount = await _bookRepository.GetCountAsync(input.FilterText, input.Title, input.YearMin, input.YearMax, input.AuthorId);
            var items = await _bookRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Title, input.YearMin, input.YearMax, input.AuthorId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BookWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<BookWithNavigationProperties>, List<BookWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<BookWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<BookWithNavigationProperties, BookWithNavigationPropertiesDto>
                (await _bookRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<BookDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Book, BookDto>(await _bookRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetAuthorLookupAsync(LookupRequestDto input)
        {
            var query = _authorRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.NameSurname != null &&
                         x.NameSurname.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Author>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Author>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(abpPermissions.Books.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        [Authorize(abpPermissions.Books.Create)]
        public virtual async Task<BookDto> CreateAsync(BookCreateDto input)
        {
            var book = ObjectMapper.Map<BookCreateDto, Book>(input);

            book = await _bookRepository.InsertAsync(book, autoSave: true);
            return ObjectMapper.Map<Book, BookDto>(book);
        }

        [Authorize(abpPermissions.Books.Edit)]
        public virtual async Task<BookDto> UpdateAsync(Guid id, BookUpdateDto input)
        {
            var book = await _bookRepository.GetAsync(id);
            ObjectMapper.Map(input, book);
            book = await _bookRepository.UpdateAsync(book);
            return ObjectMapper.Map<Book, BookDto>(book);
        }
    }
}