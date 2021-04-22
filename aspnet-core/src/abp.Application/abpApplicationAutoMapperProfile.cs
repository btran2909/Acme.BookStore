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
        }
    }
}