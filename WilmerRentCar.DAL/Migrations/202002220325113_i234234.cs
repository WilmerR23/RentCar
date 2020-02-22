namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i234234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Cedula", c => c.String());
            AddColumn("dbo.Usuarios", "TarjetaCredito", c => c.String());
            AddColumn("dbo.Usuarios", "Direccion", c => c.String());
            AddColumn("dbo.Usuarios", "Telefono", c => c.String());
            AddColumn("dbo.Usuarios", "Celular", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Celular");
            DropColumn("dbo.Usuarios", "Telefono");
            DropColumn("dbo.Usuarios", "Direccion");
            DropColumn("dbo.Usuarios", "TarjetaCredito");
            DropColumn("dbo.Usuarios", "Cedula");
        }
    }
}
