using AutoMapper;
using Ustoz_Proyekti.Data.Entities;

namespace Ustoz_Proyekti.BusinessLogic.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Author, AuthorDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();
    }
}
