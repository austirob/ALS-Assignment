using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using XboxGamesUI.Models;


namespace XboxGamesUI.DataLayer
{
    public interface  IDataService
    {
        ObservableCollection<Game> GetGames();
        void UpdateGame(Game game);
        Rating SubmitRating(Rating rating);
        void DeleteGame(Game game);
        int CreateGame(Game game);
    }
}
