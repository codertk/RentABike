namespace RentABike.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_MemberShipType_Table : DbMigration
    {
        public override void Up()
        {
            Sql("Update Membershiptypes Set Name='Pay as you go' Where id=1 ");
            Sql("Update Membershiptypes Set Name='Monthly' Where id=2 ");
            Sql("Update Membershiptypes Set Name='Quarterly' Where id=3 ");
            Sql("Update Membershiptypes Set Name='Annual' Where id=4 ");
        }
        
        public override void Down()
        {
        }
    }
}
