using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using XboxWebApi.Helpers;
using XboxWebApi.Models;

namespace XboxWebApi.Controllers
{
    public class GamesController : ApiController
    {
        
        private GamesDbContext _dbContext;
       
        public GamesController()
        {
            _dbContext = new GamesDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //GET /Games
        public IHttpActionResult GetGames()
        {
            try
            {
               
                var func = new RatingFunctions();
                var gamesWithAvgRating = func.PopulateAverageRatings(_dbContext.Games, _dbContext.Ratings);
                return Ok(gamesWithAvgRating);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
           
           
        }

       

        //GET /Games/id
        public IHttpActionResult GetGame(int rating)
        {
            try
            {
                var game = _dbContext.Games.SingleOrDefault(x => x.Id.Equals(rating));
                if (game == null)
                {
                    return NotFound();
                }

                return Ok(Mapper.Map<GameDto>(game));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
           
        }

            
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var game = Mapper.Map<Game>(gameDto);

                _dbContext.Games.Add(game);
                _dbContext.SaveChanges();

                gameDto.Id = game.Id;

                return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
          
        }


        [System.Web.Http.HttpPut]
        public void UpdateGame(GameDto gameDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                var gameFromDb = _dbContext.Games.SingleOrDefault(y => y.Id.Equals(gameDto.Id));

                if (gameFromDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                Mapper.Map(gameDto, gameFromDb);
                // TODO calculate average rating
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

            
           
        }


        [System.Web.Http.HttpDelete]
        public void DeleteGame(int id)
        {
            try
            {
                var gameFromDb = _dbContext.Games.SingleOrDefault(y => y.Id.Equals(id));

                if (gameFromDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _dbContext.Games.Remove(gameFromDb);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
           
            
        }


    }
}
