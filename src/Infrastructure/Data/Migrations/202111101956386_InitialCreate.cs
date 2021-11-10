namespace Synopsis.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Synopsis.Lists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Long(nullable: false),
                        CreateDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Synopsis.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Synopsis.Reminders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        DueDate = c.DateTime(),
                        Notes = c.String(),
                        Url = c.String(),
                        Priority = c.Int(nullable: false),
                        Completed = c.Boolean(),
                        ListId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        CreateDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Synopsis.Lists", t => t.ListId, cascadeDelete: true)
                .ForeignKey("Synopsis.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ListId)
                .Index(t => t.UserId);
            
            CreateTable(
                "Synopsis.ReminderTags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReminderId = c.Long(nullable: false),
                        TagId = c.Long(nullable: false),
                        CreateDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Synopsis.Reminders", t => t.ReminderId, cascadeDelete: true)
                .ForeignKey("Synopsis.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.ReminderId)
                .Index(t => t.TagId);
            
            CreateTable(
                "Synopsis.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Long(nullable: false),
                        CreateDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Synopsis.UserProfiles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Synopsis.UserProfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(),
                        IsDeleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Synopsis.ReminderTags", "TagId", "Synopsis.Tags");
            DropForeignKey("Synopsis.Tags", "UserId", "Synopsis.UserProfiles");
            DropForeignKey("Synopsis.Reminders", "UserId", "Synopsis.UserProfiles");
            DropForeignKey("Synopsis.Lists", "UserId", "Synopsis.UserProfiles");
            DropForeignKey("Synopsis.ReminderTags", "ReminderId", "Synopsis.Reminders");
            DropForeignKey("Synopsis.Reminders", "ListId", "Synopsis.Lists");
            DropIndex("Synopsis.Tags", new[] { "UserId" });
            DropIndex("Synopsis.ReminderTags", new[] { "TagId" });
            DropIndex("Synopsis.ReminderTags", new[] { "ReminderId" });
            DropIndex("Synopsis.Reminders", new[] { "UserId" });
            DropIndex("Synopsis.Reminders", new[] { "ListId" });
            DropIndex("Synopsis.Lists", new[] { "UserId" });
            DropTable("Synopsis.UserProfiles");
            DropTable("Synopsis.Tags");
            DropTable("Synopsis.ReminderTags");
            DropTable("Synopsis.Reminders");
            DropTable("Synopsis.Lists");
        }
    }
}
