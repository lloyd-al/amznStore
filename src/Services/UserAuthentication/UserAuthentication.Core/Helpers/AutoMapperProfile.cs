using AutoMapper;
using amznStore.Services.UserAuthentication.Core.Entities;
using amznStore.Services.UserAuthentication.Core.Models;

namespace amznStore.Services.UserAuthentication.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, AccountResponse>();

            CreateMap<ApplicationUser, AuthenticateResponse>();

            CreateMap<RegisterRequest, ApplicationUser>();

            CreateMap<UpdateRequest, ApplicationUser>();
        }
    }
}
