namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeAvgRatingFromGames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "AvgRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "AvgRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
