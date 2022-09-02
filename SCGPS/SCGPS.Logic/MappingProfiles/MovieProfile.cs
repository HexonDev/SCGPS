using AutoMapper;
using SCGPS.Data.Entities;
using SCGPS.Domain;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Results;

namespace SCGPS.Logic.MappingProfiles
{
    internal class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.MaxRating, options => options.MapFrom(source => source.ImdbRating.GetMaxRating()))
                .ForMember(dest => dest.CurrentRating, options => options.MapFrom(source => source.ImdbRating.GetCurrentRating()));
            CreateMap<SimpleResult<Movie[]>, MoviesDto>()
                .ForMember(dest => dest.Movies, options => options.MapFrom(source => source.Result));
        }
    }
}
