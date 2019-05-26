namespace GameServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayersItemsApps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(false),
                        AppearanceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayerAppearances", t => t.AppearanceId, cascadeDelete: true)
                .Index(t => t.AppearanceId);
            
            CreateTable(
                "dbo.PlayerAppearances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HairColor = c.Int(nullable: false),
                        ShirtColor = c.Int(nullable: false),
                        BootsColor = c.Int(nullable: false),
                        SpritePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerItems",
                c => new
                    {
                        Player_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Item_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "AppearanceId", "dbo.PlayerAppearances");
            DropForeignKey("dbo.PlayerItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.PlayerItems", "Player_Id", "dbo.Players");
            DropIndex("dbo.PlayerItems", new[] { "Item_Id" });
            DropIndex("dbo.PlayerItems", new[] { "Player_Id" });
            DropIndex("dbo.Players", new[] { "AppearanceId" });
            DropTable("dbo.PlayerItems");
            DropTable("dbo.PlayerAppearances");
            DropTable("dbo.Players");
            DropTable("dbo.Items");
        }
    }
}
