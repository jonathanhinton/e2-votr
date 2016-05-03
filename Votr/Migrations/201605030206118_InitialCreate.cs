namespace Votr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "CreatedBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Polls", "CreatedBy_Id");
            AddForeignKey("dbo.Polls", "CreatedBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polls", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Polls", new[] { "CreatedBy_Id" });
            DropColumn("dbo.Polls", "CreatedBy_Id");
        }
    }
}
