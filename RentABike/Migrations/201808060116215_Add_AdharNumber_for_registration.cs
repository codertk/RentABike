namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_AdharNumber_for_registration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AadharNumber", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AadharNumber");
        }
    }
}
