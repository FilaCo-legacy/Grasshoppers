namespace GameServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MainVersion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "AppearanceId", "dbo.PlayerAppearances");
            DropIndex("dbo.Players", new[] { "AppearanceId" });
            CreateTable(
                "dbo.GameSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        MissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Missions", t => t.MissionId, cascadeDelete: true)
                .Index(t => t.MissionId);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MapId = c.Int(nullable: false),
                        RequiredPlayersNumber = c.Int(nullable: false),
                        TargetScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: true)
                .Index(t => t.MapId);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MapInfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerResultEntries",
                c => new
                    {
                        PlayerId = c.Int(nullable: false),
                        GameSessionId = c.Int(nullable: false),
                        ItemId = c.Int(),
                        StunnedPlayers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerId, t.GameSessionId })
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.GameSessions", t => t.GameSessionId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId)
                .Index(t => t.GameSessionId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstPlayerItems = c.String(nullable: false),
                        SecondPlayerItems = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FirstPlayerId = c.Int(nullable: false),
                        SecondPlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.FirstPlayerId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.SecondPlayerId, cascadeDelete: true)
                .Index(t => t.FirstPlayerId)
                .Index(t => t.SecondPlayerId);
            
            CreateTable(
                "dbo.PlayerGameSessions",
                c => new
                    {
                        Player_Id = c.Int(nullable: false),
                        GameSession_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.GameSession_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.GameSessions", t => t.GameSession_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.GameSession_Id);
            
            AddColumn("dbo.Items", "Rarity", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "SpritePath", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Players", "AppearanceId");
            DropTable("dbo.PlayerAppearances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlayerAppearances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.Int(nullable: false),
                        HairColor = c.Int(nullable: false),
                        ShirtColor = c.Int(nullable: false),
                        BootsColor = c.Int(nullable: false),
                        SpritePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Players", "AppearanceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Trades", "SecondPlayerId", "dbo.Players");
            DropForeignKey("dbo.Trades", "FirstPlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerResultEntries", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerResultEntries", "GameSessionId", "dbo.GameSessions");
            DropForeignKey("dbo.PlayerResultEntries", "ItemId", "dbo.Items");
            DropForeignKey("dbo.PlayerGameSessions", "GameSession_Id", "dbo.GameSessions");
            DropForeignKey("dbo.PlayerGameSessions", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.GameSessions", "MissionId", "dbo.Missions");
            DropForeignKey("dbo.Missions", "MapId", "dbo.Maps");
            DropIndex("dbo.PlayerGameSessions", new[] { "GameSession_Id" });
            DropIndex("dbo.PlayerGameSessions", new[] { "Player_Id" });
            DropIndex("dbo.Trades", new[] { "SecondPlayerId" });
            DropIndex("dbo.Trades", new[] { "FirstPlayerId" });
            DropIndex("dbo.PlayerResultEntries", new[] { "ItemId" });
            DropIndex("dbo.PlayerResultEntries", new[] { "GameSessionId" });
            DropIndex("dbo.PlayerResultEntries", new[] { "PlayerId" });
            DropIndex("dbo.Missions", new[] { "MapId" });
            DropIndex("dbo.GameSessions", new[] { "MissionId" });
            AlterColumn("dbo.Players", "Name", c => c.String());
            AlterColumn("dbo.Items", "Name", c => c.String());
            DropColumn("dbo.Players", "SpritePath");
            DropColumn("dbo.Items", "Rarity");
            DropTable("dbo.PlayerGameSessions");
            DropTable("dbo.Trades");
            DropTable("dbo.PlayerResultEntries");
            DropTable("dbo.Maps");
            DropTable("dbo.Missions");
            DropTable("dbo.GameSessions");
            CreateIndex("dbo.Players", "AppearanceId");
            AddForeignKey("dbo.Players", "AppearanceId", "dbo.PlayerAppearances", "Id", cascadeDelete: true);
        }
    }
}
