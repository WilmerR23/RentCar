namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2323 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentaDevolucions", "MontoDia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentaDevolucions", "MontoDia", c => c.Int(nullable: false));
        }
    }
}
