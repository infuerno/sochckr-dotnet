namespace Sochckr.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        IsAnswered = c.Boolean(),
                        Title = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.BrokenLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Link = c.String(),
                        StatusCode = c.Int(nullable: false),
                        IsResolved = c.Boolean(nullable: false),
                        ResolutionReason = c.Int(nullable: false),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Question_Id", "dbo.Posts");
            DropForeignKey("dbo.BrokenLinks", "Post_Id", "dbo.Posts");
            DropIndex("dbo.BrokenLinks", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Question_Id" });
            DropTable("dbo.BrokenLinks");
            DropTable("dbo.Posts");
        }
    }
}
