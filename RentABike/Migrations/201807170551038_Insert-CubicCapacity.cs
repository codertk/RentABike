namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCubicCapacity : DbMigration
    {
        public override void Up()
        {

            Sql("Insert into CubicCapacities (CC) Values('100 CC')  ");
            Sql("Insert into CubicCapacities (CC) Values('150 CC')  ");
            Sql("Insert into CubicCapacities (CC) Values('200 CC')  ");
            Sql("Insert into CubicCapacities (CC) Values('250 CC')  ");
            Sql("Insert into CubicCapacities (CC) Values('300 CC')  ");
            Sql("Insert into CubicCapacities (CC) Values('350 CC')  ");
        }
        
        public override void Down()
        {
        }
    }
}
