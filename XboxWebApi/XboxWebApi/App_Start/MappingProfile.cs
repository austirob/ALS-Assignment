using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using XboxWebApi.Models;

namespace XboxWebApi.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<GameDto, Game>()
                .ForMember(x => x.Id, opt => opt.Ignore());


            CreateMap<Game, GameDto>()
                .ForMember(x => x.AvgRating, opt => opt.Ignore());

            CreateMap<RatingDto, Rating>()
                .ForMember(x => x.Game, opt => opt.Ignore())
                .ForMember(x => x.RatingId, opt => opt.Ignore())
                .ForMember(x => x.CreateDateTime,opt=>opt.Ignore());

            CreateMap<Rating, RatingDto>();


        }

       


    }
}