using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<MoviesEntity, Movies>()
                .ForMember(
                dst => dst.MoviesId,
                opt => opt.MapFrom(src => src.MoviesId)
                )
                .ForMember(
                dst => dst.Name,
                opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                dst => dst.Year,
                opt => opt.MapFrom(src => src.Year)
                );
        }
    }
}