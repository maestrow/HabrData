namespace DataMiner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post_FullTextIndex : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE FULLTEXT CATALOG FulltextCatalog AS DEFAULT;", true);
            Sql(@"CREATE FULLTEXT INDEX ON Posts (title, excerpt) KEY INDEX [pk_dbo.posts];", true);
        }
        
        public override void Down()
        {
            Sql("DROP FULLTEXT INDEX ON Posts", true);
            Sql("DROP FULLTEXT CATALOG FulltextCatalog", true);
        }
    }
}
