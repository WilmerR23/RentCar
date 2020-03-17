namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial2323235 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RentaDevolucions", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.RentaDevolucions", new[] { "ClienteId" });
            AddColumn("dbo.RentaDevolucions", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.RentaDevolucions", "UsuarioId");
            AddForeignKey("dbo.RentaDevolucions", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            DropColumn("dbo.RentaDevolucions", "ClienteId");
            DropTable("dbo.Clientes");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.RentaDevolucions", "ClienteId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RentaDevolucions", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.RentaDevolucions", new[] { "UsuarioId" });
            DropColumn("dbo.RentaDevolucions", "UsuarioId");
            CreateIndex("dbo.RentaDevolucions", "ClienteId");
            AddForeignKey("dbo.RentaDevolucions", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
