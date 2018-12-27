namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTM_AUTHOR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTM_BOOK",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PublishDate = c.Int(nullable: false),
                        No = c.Int(),
                        SkinType = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        SeriesId = c.Int(),
                        GenreId = c.Int(nullable: false),
                        ShelfId = c.Int(nullable: false),
                        RackId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CTM_AUTHOR", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.CTM_GENRE", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.CTM_PUBLISHER", t => t.PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.CTM_RACK", t => t.RackId, cascadeDelete: true)
                .ForeignKey("dbo.CTM_SERIES", t => t.SeriesId)
                .ForeignKey("dbo.CTM_SHELF", t => t.ShelfId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId)
                .Index(t => t.SeriesId)
                .Index(t => t.GenreId)
                .Index(t => t.ShelfId)
                .Index(t => t.RackId);
            
            CreateTable(
                "dbo.CTM_GENRE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(nullable: false, maxLength: 35),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTM_PUBLISHER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTM_SERIES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                        PublisherId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CTM_PUBLISHER", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.CTM_RACK",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RackNumber = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTM_SHELF",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTM_USERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 35),
                        UserName = c.String(nullable: false, maxLength: 35),
                        Password = c.String(nullable: false, maxLength: 35),
                        Occupation = c.String(nullable: false, maxLength: 100),
                        Gender = c.Int(nullable: false),
                        LastLoginDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                        RoleId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CTM_ROLES", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CTM_ROLES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SHELF_RACK",
                c => new
                    {
                        RackRefId = c.Int(nullable: false),
                        ShelfRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RackRefId, t.ShelfRefId })
                .ForeignKey("dbo.CTM_RACK", t => t.RackRefId, cascadeDelete: true)
                .ForeignKey("dbo.CTM_SHELF", t => t.ShelfRefId, cascadeDelete: true)
                .Index(t => t.RackRefId)
                .Index(t => t.ShelfRefId);
            
            CreateTable(
                "dbo.CTM_BOOKS_USERS",
                c => new
                    {
                        BookIdFk = c.Int(nullable: false),
                        UserIdFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookIdFk, t.UserIdFk })
                .ForeignKey("dbo.CTM_BOOK", t => t.BookIdFk, cascadeDelete: true)
                .ForeignKey("dbo.CTM_USERS", t => t.UserIdFk, cascadeDelete: true)
                .Index(t => t.BookIdFk)
                .Index(t => t.UserIdFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTM_BOOKS_USERS", "UserIdFk", "dbo.CTM_USERS");
            DropForeignKey("dbo.CTM_BOOKS_USERS", "BookIdFk", "dbo.CTM_BOOK");
            DropForeignKey("dbo.CTM_USERS", "RoleId", "dbo.CTM_ROLES");
            DropForeignKey("dbo.CTM_BOOK", "ShelfId", "dbo.CTM_SHELF");
            DropForeignKey("dbo.CTM_BOOK", "SeriesId", "dbo.CTM_SERIES");
            DropForeignKey("dbo.CTM_BOOK", "RackId", "dbo.CTM_RACK");
            DropForeignKey("dbo.SHELF_RACK", "ShelfRefId", "dbo.CTM_SHELF");
            DropForeignKey("dbo.SHELF_RACK", "RackRefId", "dbo.CTM_RACK");
            DropForeignKey("dbo.CTM_BOOK", "PublisherId", "dbo.CTM_PUBLISHER");
            DropForeignKey("dbo.CTM_SERIES", "PublisherId", "dbo.CTM_PUBLISHER");
            DropForeignKey("dbo.CTM_BOOK", "GenreId", "dbo.CTM_GENRE");
            DropForeignKey("dbo.CTM_BOOK", "AuthorId", "dbo.CTM_AUTHOR");
            DropIndex("dbo.CTM_BOOKS_USERS", new[] { "UserIdFk" });
            DropIndex("dbo.CTM_BOOKS_USERS", new[] { "BookIdFk" });
            DropIndex("dbo.SHELF_RACK", new[] { "ShelfRefId" });
            DropIndex("dbo.SHELF_RACK", new[] { "RackRefId" });
            DropIndex("dbo.CTM_USERS", new[] { "RoleId" });
            DropIndex("dbo.CTM_SERIES", new[] { "PublisherId" });
            DropIndex("dbo.CTM_BOOK", new[] { "RackId" });
            DropIndex("dbo.CTM_BOOK", new[] { "ShelfId" });
            DropIndex("dbo.CTM_BOOK", new[] { "GenreId" });
            DropIndex("dbo.CTM_BOOK", new[] { "SeriesId" });
            DropIndex("dbo.CTM_BOOK", new[] { "PublisherId" });
            DropIndex("dbo.CTM_BOOK", new[] { "AuthorId" });
            DropTable("dbo.CTM_BOOKS_USERS");
            DropTable("dbo.SHELF_RACK");
            DropTable("dbo.CTM_ROLES");
            DropTable("dbo.CTM_USERS");
            DropTable("dbo.CTM_SHELF");
            DropTable("dbo.CTM_RACK");
            DropTable("dbo.CTM_SERIES");
            DropTable("dbo.CTM_PUBLISHER");
            DropTable("dbo.CTM_GENRE");
            DropTable("dbo.CTM_BOOK");
            DropTable("dbo.CTM_AUTHOR");
        }
    }
}
