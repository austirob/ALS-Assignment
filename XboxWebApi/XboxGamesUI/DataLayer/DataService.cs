using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using AutoMapper;
using System.Collections;
using XboxGamesUI.Models;
using XboxGamesUI.ServiceLayer.Dtos;
using XboxGamesUI.ServiceLayer.REST;



namespace XboxGamesUI.DataLayer
{

    public class DataService : IDataService
    {
        private IXboxGamesService _service;
        public DataService(IXboxGamesService xboxGamesService)
        {
            _service = xboxGamesService;
        }

        public ObservableCollection<Game> GetGames()
        {
            var games = _service.GetGames().OrderBy(x=> x.Title);
            return new ObservableCollection<Game>(Mapper.Map<List<Game>>(games));
        }


        public void UpdateGame(Game game)
        {
            var gameDto =  Mapper.Map<GameDto>(game);
            _service.UpdateGame(gameDto);
        }

        public Rating SubmitRating(Rating rating)
        {
            
            var ratingDto = Mapper.Map<RatingDto>(rating);
            var newRating = _service.SubmitRating(ratingDto);
            return Mapper.Map<Rating>(newRating);
            
        }

        public void DeleteGame(Game game)
        {
            _service.DeleteGame(game.Id);
        }


      
        public int CreateGame(Game game)
        {
            
            var gameDto = Mapper.Map<GameDto>(game);
            var newGameDto = _service.CreateGame(gameDto);
            return newGameDto.Id;
        }

    }
}
