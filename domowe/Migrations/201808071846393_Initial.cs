namespace domowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        HouseNumber = c.String(),
                        FlatNumber = c.String(),
                        Description = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        Parent1Id = c.Int(),
                        Parent2Id = c.Int(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Parent", t => t.Parent1Id)
                .ForeignKey("dbo.Parent", t => t.Parent2Id)
                .Index(t => t.AddressId)
                .Index(t => t.Parent1Id)
                .Index(t => t.Parent2Id);
            
            CreateTable(
                "dbo.Parent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressId = c.Int(nullable: false),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Lastname = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grade", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Grade", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "Parent2Id", "dbo.Parent");
            DropForeignKey("dbo.Student", "Parent1Id", "dbo.Parent");
            DropForeignKey("dbo.Parent", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Student", "AddressId", "dbo.Address");
            DropIndex("dbo.Teacher", new[] { "SubjectId" });
            DropIndex("dbo.Parent", new[] { "AddressId" });
            DropIndex("dbo.Student", new[] { "Parent2Id" });
            DropIndex("dbo.Student", new[] { "Parent1Id" });
            DropIndex("dbo.Student", new[] { "AddressId" });
            DropIndex("dbo.Grade", new[] { "SubjectId" });
            DropIndex("dbo.Grade", new[] { "TeacherId" });
            DropIndex("dbo.Grade", new[] { "StudentId" });
            DropTable("dbo.Teacher");
            DropTable("dbo.Subject");
            DropTable("dbo.Parent");
            DropTable("dbo.Student");
            DropTable("dbo.Grade");
            DropTable("dbo.Address");
        }
    }
}
