namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRatings1 : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (3,'2018-10-18','11')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (4,'2018-10-18','11')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (5,'2018-10-18','11')");


            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (5,'2018-10-18','12')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (5,'2018-10-18','12')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (5,'2018-10-18','12')");


            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (1,'2018-10-18','13')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (2,'2018-10-18','13')");
            //Sql("INSERT INTO Ratings(Stars,CreateDateTime,GameId) VALUES (3,'2018-10-18','13')");
        }
        
        public override void Down()
        {
        }
    }
}
