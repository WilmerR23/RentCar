namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti232 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imagenes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contenido = c.Binary(),
                        Formato = c.String(),
                        VehiculoId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Vehículo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehículo", t => t.Vehículo_Id)
                .Index(t => t.Vehículo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imagenes", "Vehículo_Id", "dbo.Vehículo");
            DropIndex("dbo.Imagenes", new[] { "Vehículo_Id" });
            DropTable("dbo.Imagenes");
        }
    }
}
