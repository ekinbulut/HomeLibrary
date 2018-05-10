namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.XXX_AUTHOR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_BOOK",
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
                .ForeignKey("dbo.XXX_AUTHOR", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.XXX_GENRE", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.XXX_PUBLISHER", t => t.PublisherId, cascadeDelete: true)
                .ForeignKey("dbo.XXX_RACK", t => t.RackId, cascadeDelete: true)
                .ForeignKey("dbo.XXX_SERIES", t => t.SeriesId)
                .ForeignKey("dbo.XXX_SHELF", t => t.ShelfId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId)
                .Index(t => t.SeriesId)
                .Index(t => t.GenreId)
                .Index(t => t.ShelfId)
                .Index(t => t.RackId);
            
            CreateTable(
                "dbo.XXX_GENRE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(nullable: false, maxLength: 35),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_PUBLISHER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_SERIES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                        PublisherId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.XXX_PUBLISHER", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.XXX_RACK",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RackNumber = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_SHELF",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_USERS",
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
                .ForeignKey("dbo.XXX_ROLES", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.XXX_ROLES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        CreationTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.XXX_SHELF_RACK",
                c => new
                    {
                        RackRefId = c.Int(nullable: false),
                        ShelfRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RackRefId, t.ShelfRefId })
                .ForeignKey("dbo.XXX_RACK", t => t.RackRefId, cascadeDelete: true)
                .ForeignKey("dbo.XXX_SHELF", t => t.ShelfRefId, cascadeDelete: true)
                .Index(t => t.RackRefId)
                .Index(t => t.ShelfRefId);
            
            CreateTable(
                "dbo.XXX_BOOKS_USERS",
                c => new
                    {
                        BookIdFk = c.Int(nullable: false),
                        UserIdFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookIdFk, t.UserIdFk })
                .ForeignKey("dbo.XXX_BOOK", t => t.BookIdFk, cascadeDelete: true)
                .ForeignKey("dbo.XXX_USERS", t => t.UserIdFk, cascadeDelete: true)
                .Index(t => t.BookIdFk)
                .Index(t => t.UserIdFk);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XXX_BOOKS_USERS", "UserIdFk", "dbo.XXX_USERS");
            DropForeignKey("dbo.XXX_BOOKS_USERS", "BookIdFk", "dbo.XXX_BOOK");
            DropForeignKey("dbo.XXX_USERS", "RoleId", "dbo.XXX_ROLES");
            DropForeignKey("dbo.XXX_BOOK", "ShelfId", "dbo.XXX_SHELF");
            DropForeignKey("dbo.XXX_BOOK", "SeriesId", "dbo.XXX_SERIES");
            DropForeignKey("dbo.XXX_BOOK", "RackId", "dbo.XXX_RACK");
            DropForeignKey("dbo.XXX_SHELF_RACK", "ShelfRefId", "dbo.XXX_SHELF");
            DropForeignKey("dbo.XXX_SHELF_RACK", "RackRefId", "dbo.XXX_RACK");
            DropForeignKey("dbo.XXX_BOOK", "PublisherId", "dbo.XXX_PUBLISHER");
            DropForeignKey("dbo.XXX_SERIES", "PublisherId", "dbo.XXX_PUBLISHER");
            DropForeignKey("dbo.XXX_BOOK", "GenreId", "dbo.XXX_GENRE");
            DropForeignKey("dbo.XXX_BOOK", "AuthorId", "dbo.XXX_AUTHOR");
            DropIndex("dbo.XXX_BOOKS_USERS", new[] { "UserIdFk" });
            DropIndex("dbo.XXX_BOOKS_USERS", new[] { "BookIdFk" });
            DropIndex("dbo.XXX_SHELF_RACK", new[] { "ShelfRefId" });
            DropIndex("dbo.XXX_SHELF_RACK", new[] { "RackRefId" });
            DropIndex("dbo.XXX_USERS", new[] { "RoleId" });
            DropIndex("dbo.XXX_SERIES", new[] { "PublisherId" });
            DropIndex("dbo.XXX_BOOK", new[] { "RackId" });
            DropIndex("dbo.XXX_BOOK", new[] { "ShelfId" });
            DropIndex("dbo.XXX_BOOK", new[] { "GenreId" });
            DropIndex("dbo.XXX_BOOK", new[] { "SeriesId" });
            DropIndex("dbo.XXX_BOOK", new[] { "PublisherId" });
            DropIndex("dbo.XXX_BOOK", new[] { "AuthorId" });
            DropTable("dbo.XXX_BOOKS_USERS");
            DropTable("dbo.XXX_SHELF_RACK");
            DropTable("dbo.XXX_ROLES");
            DropTable("dbo.XXX_USERS");
            DropTable("dbo.XXX_SHELF");
            DropTable("dbo.XXX_RACK");
            DropTable("dbo.XXX_SERIES");
            DropTable("dbo.XXX_PUBLISHER");
            DropTable("dbo.XXX_GENRE");
            DropTable("dbo.XXX_BOOK");
            DropTable("dbo.XXX_AUTHOR");
        }
    }
}
