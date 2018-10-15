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
    public class RatingController : ApiController
    {
        
        private GamesDbContext _dbContext;
        public RatingController()
        {
            _dbContext = new GamesDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

       

        [System.Web.Http.HttpPost]
        public IHttpActionResult SubmitRating(RatingDto ratingDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var rating = Mapper.Map<Rating>(ratingDto);
                rating.CreateDateTime = DateTime.UtcNow;
                _dbContext.Ratings.Add(rating);
                _dbContext.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + rating.RatingId),
                    Mapper.Map<RatingDto>(rating));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
           
           
        }



        //GET /Ratings
        public IHttpActionResult GetRatings()
        {
            try
            {
                var ratings = _dbContext.Ratings;
                var ratingDtos = ratings.ToList().Select(Mapper.Map<RatingDto>);
                return Ok(ratingDtos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
          
        }
    }
}
