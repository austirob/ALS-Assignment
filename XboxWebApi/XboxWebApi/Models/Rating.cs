using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XboxWebApi.Models
{
    public class Rating
    {
        [Required]
        public int RatingId { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public int Stars { get; set; }
        public DateTime CreateDateTime { get; set; }


    }
}