using AutoMapper;
using SCGPS.Data.Entities;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Results;

namespace SCGPS.Logic.MappingProfiles
{
    internal class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<SimpleResult<Movie[]>, MoviesDto>()
                .ForMember(dest => dest.Movies, options => options.MapFrom(source => source.Result));
        }
    }
}
