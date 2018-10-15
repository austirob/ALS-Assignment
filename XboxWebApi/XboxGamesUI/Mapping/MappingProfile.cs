using AutoMapper;
using XboxGamesUI.Models;
using XboxGamesUI.ServiceLayer.Dtos;

namespace XboxGamesUI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<GameDto, Game>().ForMember(dest=> dest.AvgRating,opt=> opt.ResolveUsing(new RatingsResolver()));
            CreateMap<Game, GameDto>();
        }

       


    }
}    