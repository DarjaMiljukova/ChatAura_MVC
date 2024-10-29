namespace ChatAura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        ChatRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoom_Id)
                .Index(t => t.ChatRoom_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ChatRoom_Id", "dbo.ChatRooms");
            DropIndex("dbo.Messages", new[] { "ChatRoom_Id" });
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.ChatRooms");
        }
    }
}
