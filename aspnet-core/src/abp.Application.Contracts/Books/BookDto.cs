using System;
using Volo.Abp.Application.Dtos;

namespace abp.Books
{
    public class BookDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Guid? AuthorId { get; set; }
    }
}