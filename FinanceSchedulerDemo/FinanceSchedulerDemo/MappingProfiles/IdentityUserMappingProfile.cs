using AutoMapper;
using Domain.Models;
using Domain.User;

namespace FinanceSchedulerDemo.MappingProfiles
{
    public class IdentityUserMappingProfile : Profile
    {
        public IdentityUserMappingProfile()
        {
            CreateMap<AppUser, UserModel>()
                .ForMember(user => user.Id, options => options.MapFrom(identityUser => identityUser.Id))
                .ForMember(user => user.UserName, options => options.MapFrom(identityUser => identityUser.UserName))
                .ForMember(user => user.Email, options => options.MapFrom(identityUser => identityUser.Email))
                .ForMember(user => user.Balance, options => options.MapFrom(identityUser => identityUser.Balance))
                .ReverseMap();
        }
    }
}
