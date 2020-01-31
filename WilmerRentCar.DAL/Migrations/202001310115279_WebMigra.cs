namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WebMigra : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personas", "TipoPersonaId", "dbo.TipoPersonas");
            DropForeignKey("dbo.Clientes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Empleadoes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Inspección", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Inspección", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Inspección", "VehiculoId", "dbo.Vehículo");
            DropForeignKey("dbo.RentaDevolucions", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Empleadoes");
            DropIndex("dbo.Clientes", new[] { "PersonaId" });
            DropIndex("dbo.Personas", new[] { "TipoPersonaId" });
            DropIndex("dbo.Empleadoes", new[] { "PersonaId" });
            DropIndex("dbo.Inspección", new[] { "VehiculoId" });
            DropIndex("dbo.Inspección", new[] { "ClienteId" });
            DropIndex("dbo.Inspección", new[] { "EmpleadoId" });
            DropIndex("dbo.RentaDevolucions", new[] { "EmpleadoId" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoId" });
            AddColumn("dbo.Usuarios", "Correo", c => c.String());
            DropColumn("dbo.Clientes", "LimiteCredito");
            DropColumn("dbo.Clientes", "PersonaId");
            DropColumn("dbo.RentaDevolucions", "EmpleadoId");
            DropColumn("dbo.Usuarios", "EmpleadoId");
            DropTable("dbo.Personas");
            DropTable("dbo.TipoPersonas");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Inspección");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inspección",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehiculoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        CantidadCombustible = c.String(),
                        FechaInspeccion = c.DateTime(nullable: false),
                        Ralladuras = c.Boolean(nullable: false),
                        GomaRepuesta = c.Boolean(nullable: false),
                        Gato = c.Boolean(nullable: false),
                        RoturaCristal = c.Boolean(nullable: false),
                        Goma1 = c.Boolean(nullable: false),
                        Goma2 = c.Boolean(nullable: false),
                        Goma3 = c.Boolean(nullable: false),
                        Goma4 = c.Boolean(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TandaLabor = c.String(),
                        PorCientoComision = c.String(),
                        FechaIngreso = c.DateTime(nullable: false),
                        PersonaId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoPersonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        TipoPersonaId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Usuarios", "EmpleadoId", c => c.Int(nullable: false));
            AddColumn("dbo.RentaDevolucions", "EmpleadoId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "PersonaId", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "LimiteCredito", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Correo");
            CreateIndex("dbo.Usuarios", "EmpleadoId");
            CreateIndex("dbo.RentaDevolucions", "EmpleadoId");
            CreateIndex("dbo.Inspección", "EmpleadoId");
            CreateIndex("dbo.Inspección", "ClienteId");
            CreateIndex("dbo.Inspección", "VehiculoId");
            CreateIndex("dbo.Empleadoes", "PersonaId");
            CreateIndex("dbo.Personas", "TipoPersonaId");
            CreateIndex("dbo.Clientes", "PersonaId");
            AddForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Empleadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RentaDevolucions", "EmpleadoId", "dbo.Empleadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inspección", "VehiculoId", "dbo.Vehículo", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inspección", "EmpleadoId", "dbo.Empleadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Inspección", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Empleadoes", "PersonaId", "dbo.Personas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clientes", "PersonaId", "dbo.Personas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Personas", "TipoPersonaId", "dbo.TipoPersonas", "Id", cascadeDelete: true);
        }
    }
}
