using System;
using abp.Shared;
using abp.Authors;
using AutoMapper;
using abp.Users;
using Volo.Abp.AutoMapper;

namespace abp
{
    public class abpApplicationAutoMapperProfile : Profile
    {
        public abpApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, AppUserDto>().Ignore(x => x.ExtraProperties);

            CreateMap<AuthorCreateDto, Author>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<AuthorUpdateDto, Author>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
            CreateMap<Author, AuthorDto>();
        }
    }
}