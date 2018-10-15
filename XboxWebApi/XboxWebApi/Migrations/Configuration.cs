using XboxWebApi.Models;

namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<XboxWebApi.Models.GamesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XboxWebApi.Models.GamesDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Games.AddOrUpdate(x => x.Id,
                new Game() {Title = "James Bond 007: Agent Under Fire" ,Desc = @"A first-person shooter video game based on the James Bond franchise. Developed and published by Electronic Arts, it was released for PlayStation 2, GameCube and Xbox game consoles. It is the fourth Bond game which is not based on a film or book in the James Bond series, following James Bond 007: The Duel, James Bond 007 and EA's own 007 Racing. The game's story arc continues in the following sequel, Nightfire, released a year later. Unlike previous Bond games which featured the likeness of then current Bond actor Pierce Brosnan, Agent Under Fire used the voice of Adam Blackwood and the likeness of English actor Andrew Bicknell for Bond." },
                
                new Game() {Title = "187 Ride or Die", Desc = @"187 Ride or Die is a video game for the PlayStation 2 and Xbox, developed and published by Ubisoft. In order to become 'top dog' of the game, the player must race and defeat opponents through a variety of different stages all set in Los Angeles's infamous South Central region. 
                                                The game's title comes from two phrases common in the subculture. 187 is the California Penal Code section that defines murder. It has come into general use among gangs in the United States as a synonym for murder, and this usage has passed into popular culture via gangsta rap. 'Ride or die' is a combination of the phrases 'ride it out' and 'die trying', meaning one is willing to do anything even if it involves personal risk. 
                                                If playing with another player, one can be the driver and the other can be the shooter. This can be done in the story and online mode. There are a variety of modes available to the player." },
                
                new Game() {Title = "2002 FIFA World Cup",@Desc= "2002 FIFA World Cup, sometimes known as FIFA World Cup 2002, is the second EA Sports official World Cup video game developed by EA Canada and Creations, with Intelligent Games assisting for PS2, Xbox, Windows, and Nintendo GameCube platform and Tose Software also assisting the GameCube version, the game was published by EA Sports in North America and Europe and published by Electronic Arts Victor in Japan. \r\nAn amalgamation between the game engines of FIFA Football 2002 and FIFA Football 2003, the game still incorporates the power bar for shots and crosses but with a steeper learning curve and customisation of the chances of being penalised by the match referee. Some kits are licensed, along with player likeness and the stadia of the 2002 FIFA World Cup. Unlike the previous games in the FIFA series, the game had an original soundtrack performed by the Vancouver Symphony Orchestra. It was released for Windows, PlayStation, PlayStation 2, Nintendo GameCube, and Xbox." }
            );

           

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
