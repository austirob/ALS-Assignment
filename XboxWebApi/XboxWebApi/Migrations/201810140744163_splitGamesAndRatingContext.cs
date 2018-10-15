namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class splitGamesAndRatingContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "GameId", "dbo.Games");
            DropIndex("dbo.Ratings", new[] { "GameId" });
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Stars = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId);
            
            CreateIndex("dbo.Ratings", "GameId");
            AddForeignKey("dbo.Ratings", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
