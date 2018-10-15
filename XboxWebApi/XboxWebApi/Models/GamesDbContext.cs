using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XboxWebApi.Models
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext()
        {

        }
        public DbSet<Game> Games { get; set; } 
        public DbSet<Rating> Ratings { get; set; }

       

    }

}