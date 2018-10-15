using System.Data.Entity.ModelConfiguration.Configuration;

namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
           
            //Sql(@"INSERT INTO Games (Title,Desc) VALUES ('James Bond 007- Agent Under Fire','A first-person shooter video game based on the James Bond franchise. Developed and published by Electronic Arts it was released for PlayStation 2 GameCube and Xbox game consoles. It is the fourth Bond game which is not based on a film or book in the James Bond series, following James Bond 007: The Duel- James Bond 007 and EAs own 007 Racing. The games story arc continues in the following sequel- Nightfire released a year later. Unlike previous Bond games which featured the likeness of then current Bond actor Pierce Brosnan- Agent Under Fire used the voice of Adam Blackwood and the likeness of English actor Andrew Bicknell for Bond.')");

            //Sql(@"INSERT INTO Games (Title,Desc) VALUES ('AFL (video game series)','The AFL video game series is a series of Australian rules football video games based on the AFL. Released originally by Beam Software, it has since been developed by several other game developers.')");

            //Sql(@"INSERT INTO Games (Title,Desc) VALUES ('2002 FIFA World Cup','The second EA Sports official World Cup video game developed by EA Canada and Creations with Intelligent Games assisting for PS2.')");

            //Sql(@"INSERT INTO Games (Title,Desc) VALUES ('187 Ride or Die','187 Ride or Die is a video game for the PlayStation 2 and Xbox developed and published by Ubisoft. In order to become top dog of the game the player must race and defeat opponents through a variety of different stages all set in Los Angeles infamous South Central region.')");



        }
        
        public override void Down()
        {
        }
    }
}
