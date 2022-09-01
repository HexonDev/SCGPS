using AutoMapper;
using SCGPS.Data.Entities;
using SCGPS.Logic.Services.OmdbSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.MappingProfiles
{
    internal class OmdMovieProfile : Profile
    {
        public OmdMovieProfile()
        {
            CreateMap<OmdbMovie, Movie>()
                .ForMember(dest => dest.Year, options => options.MapFrom(source => DateTime.Parse($"{source.Year}-01-01")));
                
        }
    }
}
