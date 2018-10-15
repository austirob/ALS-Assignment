using System;
using XboxGamesUI.ServiceLayer.Dtos;
using System.Collections.Generic;


namespace XboxGamesUI.ServiceLayer.REST
{
    public interface IXboxGamesService
    {
        List<GameDto> GetGames();
        GameDto CreateGame(GameDto GameDto);
        RatingDto SubmitRating(RatingDto ratingDto);
        void UpdateGame(GameDto GameDto);
        void DeleteGame(int id);

    }
}
