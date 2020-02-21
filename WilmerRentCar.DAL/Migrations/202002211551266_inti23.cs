namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehículo", "Año", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehículo", "Año");
        }
    }
}
