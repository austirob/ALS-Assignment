using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XboxWebApi.App_Start;
using XboxWebApi.Helpers;
using XboxWebApi.Models;

namespace XboxWebApi.Tests
{
    [TestClass]
    public class TestRatingFunctions
    {

        [TestInitialize]
        public void Setup()
        {

            AutoMapper.Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }

        [TestMethod]
        public void PopulateAverageRatings()
        {
           

            var games = new List<Game>();
            var ratings = new List<Rating>();

           
            for (int i = 0; i < 4; i++)
            {
                var game = new Game() { Id = i, Desc = $"Description of game {i}", Title = $"game {i} title" };
                games.Add(game);

            }


            var firstGame = games[0];


            var rating = new Rating() {Game = firstGame, CreateDateTime = DateTime.UtcNow, GameId = firstGame.Id,RatingId = 1,Stars = 5};
            ratings.Add(rating);
            var rating1 = new Rating() {Game = firstGame, CreateDateTime = DateTime.UtcNow, GameId = firstGame.Id,RatingId = 2,Stars = 1};
            ratings.Add(rating1);
            var rating2 = new Rating() { Game = firstGame, CreateDateTime = DateTime.UtcNow, GameId = firstGame.Id, RatingId = 3, Stars = 4 };
            ratings.Add(rating2);


            var rf = new RatingFunctions();
            var gameDto = rf.PopulateAverageRatings(games,ratings).SingleOrDefault(x=>x.Id.Equals(firstGame.Id));

            Assert.AreEqual(gameDto.AvgRating,3);


        }
    }
}
