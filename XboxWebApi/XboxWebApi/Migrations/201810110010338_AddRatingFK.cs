namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Game_Id", "dbo.Games");
            DropIndex("dbo.Ratings", new[] { "Game_Id" });
            RenameColumn(table: "dbo.Ratings", name: "Game_Id", newName: "GameId");
            AlterColumn("dbo.Ratings", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "GameId");
            AddForeignKey("dbo.Ratings", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "GameId", "dbo.Games");
            DropIndex("dbo.Ratings", new[] { "GameId" });
            AlterColumn("dbo.Ratings", "GameId", c => c.Int());
            RenameColumn(table: "dbo.Ratings", name: "GameId", newName: "Game_Id");
            CreateIndex("dbo.Ratings", "Game_Id");
            AddForeignKey("dbo.Ratings", "Game_Id", "dbo.Games", "Id");
        }
    }
}
