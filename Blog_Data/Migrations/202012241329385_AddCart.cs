namespace Blog_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Posts", "Cart_ID", c => c.Int());
            CreateIndex("dbo.Posts", "Cart_ID");
            AddForeignKey("dbo.Posts", "Cart_ID", "dbo.Carts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Cart_ID", "dbo.Carts");
            DropIndex("dbo.Posts", new[] { "Cart_ID" });
            DropColumn("dbo.Posts", "Cart_ID");
            DropTable("dbo.Carts");
        }
    }
}
