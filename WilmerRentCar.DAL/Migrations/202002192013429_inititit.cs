namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inititit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TarjetaCredito = c.String(),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentaDevolucions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Renta = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        MontoDia = c.Int(nullable: false),
                        Dias = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehículo", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Vehículo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Chasis = c.String(),
                        Motor = c.String(),
                        Placa = c.String(),
                        TipoVehiculoId = c.Int(nullable: false),
                        MarcaId = c.Int(nullable: false),
                        ModeloId = c.Int(nullable: false),
                        TipoCombustibleId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCombustibles", t => t.TipoCombustibleId, cascadeDelete: true)
                .ForeignKey("dbo.TipoVehiculoes", t => t.TipoVehiculoId, cascadeDelete: true)
                .Index(t => t.TipoVehiculoId)
                .Index(t => t.MarcaId)
                .Index(t => t.ModeloId)
                .Index(t => t.TipoCombustibleId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MarcaId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: false)
                .Index(t => t.MarcaId);
            
            CreateTable(
                "dbo.TipoCombustibles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoVehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clave = c.String(),
                        Correo = c.String(),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehículo", "TipoVehiculoId", "dbo.TipoVehiculoes");
            DropForeignKey("dbo.Vehículo", "TipoCombustibleId", "dbo.TipoCombustibles");
            DropForeignKey("dbo.RentaDevolucions", "VehiculoId", "dbo.Vehículo");
            DropForeignKey("dbo.Vehículo", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Vehículo", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.RentaDevolucions", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            DropIndex("dbo.Vehículo", new[] { "TipoCombustibleId" });
            DropIndex("dbo.Vehículo", new[] { "ModeloId" });
            DropIndex("dbo.Vehículo", new[] { "MarcaId" });
            DropIndex("dbo.Vehículo", new[] { "TipoVehiculoId" });
            DropIndex("dbo.RentaDevolucions", new[] { "ClienteId" });
            DropIndex("dbo.RentaDevolucions", new[] { "VehiculoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TipoVehiculoes");
            DropTable("dbo.TipoCombustibles");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Vehículo");
            DropTable("dbo.RentaDevolucions");
            DropTable("dbo.Clientes");
        }
    }
}
