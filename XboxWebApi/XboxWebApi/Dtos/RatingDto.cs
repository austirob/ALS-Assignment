using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XboxWebApi.Models
{
    public class RatingDto
    {
        [Required]
        public int GameId { get; set; }
        public int Stars { get; set; }
        
    }
}