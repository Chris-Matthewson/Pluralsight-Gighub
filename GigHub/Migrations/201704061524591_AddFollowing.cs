namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFollowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                {
                    FollowerId = c.String(nullable: false, maxLength: 128),
                    FoloweeId = c.String(nullable: false, maxLength: 128),
                    Followee_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.FollowerId, t.FoloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Followee_Id)
                .Index(t => t.FollowerId)
                .Index(t => t.Followee_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Followee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Followee_Id" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropTable("dbo.Followings");
        }
    }
}
