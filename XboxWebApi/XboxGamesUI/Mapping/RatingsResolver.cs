using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XboxGamesUI.Models;
using XboxGamesUI.ServiceLayer.Dtos;

namespace XboxGamesUI.Mapping
{

    //public class RatingsResolver : IValueResolver<GameDto, Game, int[]>
    //{
    //    public int[] Resolve(GameDto source, Game destination, int[] destMember, ResolutionContext context)
    //    {
    //        var avg = source.AvgRating ?? 0;
    //        return new int[avg];
    //    }
    //}


    public class RatingsResolver : IValueResolver<GameDto, Game, ObservableCollection<Object>>
    {
        public ObservableCollection<Object> Resolve(GameDto source, Game destination, ObservableCollection<Object> destMember, ResolutionContext context)
        {
            var avg = source.AvgRating ?? 0;

            var obvsRatingsColl = new ObservableCollection<Object>();

            for (int i = 0; i < avg; i++)
            {
                obvsRatingsColl.Add(new object());
            }

            return obvsRatingsColl;
            //return new int[avg];
        }
    }

}
