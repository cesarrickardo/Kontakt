namespace Kontakt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Person_PersonId", "dbo.People");
            DropIndex("dbo.People", new[] { "Person_PersonId" });
            DropTable("dbo.People");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.PersonId);
            
            CreateIndex("dbo.People", "Person_PersonId");
            AddForeignKey("dbo.People", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
