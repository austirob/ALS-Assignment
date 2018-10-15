using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XboxWebApi.Models;

namespace XboxWebApi.Helpers
{
    public class RatingFunctions
    {
        
        public IEnumerable<GameDto> PopulateAverageRatings(IEnumerable<Game> games, IEnumerable<Rating> ratings)
        {
            // could have done this in automapperResolver instead

            var gamesWithRatings = new List<GameDto>();

            foreach (var game in games)
            {
                
                double? avgrating = null;
                var gameRating = ratings.Where(x => x.GameId.Equals(game.Id));
                if (gameRating.Any())
                {
                    avgrating = ratings.Where(x => x.GameId.Equals(game.Id)).Average(x => x.Stars);
                }


                var gameDto = AutoMapper.Mapper.Map<GameDto>(game);

                if (avgrating != null)
                {
                    gameDto.AvgRating = (int?) Math.Round(Convert.ToDouble(avgrating), 0);
                }

                gamesWithRatings.Add(gameDto);
            }
            return gamesWithRatings;
        }

    }
}