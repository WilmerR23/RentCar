namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti2323454534 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imagenes", "Vehículo_Id", "dbo.Vehículo");
            DropIndex("dbo.Imagenes", new[] { "Vehículo_Id" });
            RenameColumn(table: "dbo.Imagenes", name: "Vehículo_Id", newName: "VehículoId");
            AlterColumn("dbo.Imagenes", "VehículoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Imagenes", "VehículoId");
            AddForeignKey("dbo.Imagenes", "VehículoId", "dbo.Vehículo", "Id", cascadeDelete: true);
            DropColumn("dbo.Imagenes", "VehiculoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagenes", "VehiculoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Imagenes", "VehículoId", "dbo.Vehículo");
            DropIndex("dbo.Imagenes", new[] { "VehículoId" });
            AlterColumn("dbo.Imagenes", "VehículoId", c => c.Int());
            RenameColumn(table: "dbo.Imagenes", name: "VehículoId", newName: "Vehículo_Id");
            CreateIndex("dbo.Imagenes", "Vehículo_Id");
            AddForeignKey("dbo.Imagenes", "Vehículo_Id", "dbo.Vehículo", "Id");
        }
    }
}
