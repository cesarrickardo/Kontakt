namespace Kontakt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Person_info : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Addres = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        Email = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Person_PersonId", "dbo.People");
            DropIndex("dbo.People", new[] { "Person_PersonId" });
            DropTable("dbo.People");
        }
    }
}
