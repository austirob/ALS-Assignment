using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XboxWebApi.Models
{
    public class GameDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Desc {get; set; }
        public int? AvgRating { get; set; }

    }
}