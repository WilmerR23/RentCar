namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti2323454534rtrtjk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagenes", "ContenidoBase64", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Imagenes", "ContenidoBase64");
        }
    }
}
