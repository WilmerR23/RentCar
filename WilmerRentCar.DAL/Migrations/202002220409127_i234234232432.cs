namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i234234232432 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehículo", "Monto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehículo", "Monto");
        }
    }
}
