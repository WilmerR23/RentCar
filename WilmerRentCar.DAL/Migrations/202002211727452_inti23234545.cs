namespace WilmerRentCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti23234545 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehículo", "TipoCombustibleId", "dbo.TipoCombustibles");
            DropIndex("dbo.Vehículo", new[] { "TipoCombustibleId" });
            DropColumn("dbo.Vehículo", "Chasis");
            DropColumn("dbo.Vehículo", "Motor");
            DropColumn("dbo.Vehículo", "TipoCombustibleId");
            DropTable("dbo.TipoCombustibles");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Vehículo", "TipoCombustibleId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehículo", "Motor", c => c.String());
            AddColumn("dbo.Vehículo", "Chasis", c => c.String());
            CreateIndex("dbo.Vehículo", "TipoCombustibleId");
            AddForeignKey("dbo.Vehículo", "TipoCombustibleId", "dbo.TipoCombustibles", "Id", cascadeDelete: true);
        }
    }
}
