namespace Kontakt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveList : DbMigration
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
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
