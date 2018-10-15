using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XboxGamesUI.Models
{
    public class Rating
    {       
        public int GameId { get; set; }
        //rounded to nearest whole
        public int Stars { get; set; }
        
    }
}