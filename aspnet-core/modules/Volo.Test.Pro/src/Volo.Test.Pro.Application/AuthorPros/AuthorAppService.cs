using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using abp.Permissions;

namespace Volo.Test.Pro.AuthorPros
{
    [RemoteService(IsEnabled = false)]
    [Authorize(abpPermissions.Authors.Default)]
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorAppService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public virtual async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorsInput input)
        {
            var totalCount = await _authorRepository.GetCountAsync(input.FilterText, input.NameSurname, input.AgeMin, input.AgeMax);
            var items = await _authorRepository.GetListAsync(input.FilterText, input.NameSurname, input.AgeMin, input.AgeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AuthorDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(items)
            };
        }

        public virtual async Task<AuthorDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Author, AuthorDto>(await _authorRepository.GetAsync(id));
        }

        [Authorize(abpPermissions.Authors.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        [Authorize(abpPermissions.Authors.Create)]
        public virtual async Task<AuthorDto> CreateAsync(AuthorCreateDto input)
        {
            var author = ObjectMapper.Map<AuthorCreateDto, Author>(input);

            author = await _authorRepository.InsertAsync(author, autoSave: true);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        [Authorize(abpPermissions.Authors.Edit)]
        public virtual async Task<AuthorDto> UpdateAsync(Guid id, AuthorUpdateDto input)
        {
            var author = await _authorRepository.GetAsync(id);
            ObjectMapper.Map(input, author);
            author = await _authorRepository.UpdateAsync(author);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
    }
}