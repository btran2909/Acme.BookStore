using System;
using Volo.Abp.Application.Dtos;

namespace abp.Authors
{
    public class AuthorDto : FullAuditedEntityDto<Guid>
    {
        public string NameSurname { get; set; }
        public int Age { get; set; }
    }
}