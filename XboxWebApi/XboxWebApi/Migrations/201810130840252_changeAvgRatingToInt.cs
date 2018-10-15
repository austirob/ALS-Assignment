namespace XboxWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAvgRatingToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "Stars", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Stars", c => c.Double(nullable: false));
        }
    }
}
