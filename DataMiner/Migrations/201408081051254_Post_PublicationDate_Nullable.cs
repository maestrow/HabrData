namespace DataMiner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post_PublicationDate_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PublicationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PublicationDate", c => c.DateTime(nullable: false));
        }
    }
}
