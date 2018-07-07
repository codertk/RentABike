namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubcribedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscibedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscibedToNewsLetter");
        }
    }
}