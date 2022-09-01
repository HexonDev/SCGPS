using AutoMapper;
using SCGPS.Data.Entities;
using SCGPS.Domain.Dto;
using SCGPS.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCGPS.Logic.MappingProfiles
{
    internal class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<SimpleResult<Review[]>, ReviewsDto>()
                .ForMember(dest => dest.Reviews, options => options.MapFrom(source => source.Result));
        }
    }
}
