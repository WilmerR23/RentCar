namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2392923423432 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentaDevolucions", "ServicioDomicilio", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentaDevolucions", "ServicioDomicilio");
        }
    }
}
