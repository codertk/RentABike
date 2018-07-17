namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BikeDetailedInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CubicCapacities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CC = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Bikes", "Model", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bikes", "DateOfPurchase", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bikes", "NumberOfBikes", c => c.Int(nullable: false));
            AddColumn("dbo.Bikes", "CubicCapacityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bikes", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Bikes", "CubicCapacityId");
            AddForeignKey("dbo.Bikes", "CubicCapacityId", "dbo.CubicCapacities", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "CubicCapacityId", "dbo.CubicCapacities");
            DropIndex("dbo.Bikes", new[] { "CubicCapacityId" });
            AlterColumn("dbo.Bikes", "Name", c => c.String());
            DropColumn("dbo.Bikes", "CubicCapacityId");
            DropColumn("dbo.Bikes", "NumberOfBikes");
            DropColumn("dbo.Bikes", "DateOfPurchase");
            DropColumn("dbo.Bikes", "Model");
            DropTable("dbo.CubicCapacities");
        }
    }
}
