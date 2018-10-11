namespace Mensageiro.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mensagem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(nullable: false),
                        Horario = c.DateTime(nullable: false),
                        Destinatario_Id = c.String(nullable: false, maxLength: 128),
                        Remetente_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Destinatario_Id)
                .ForeignKey("dbo.Usuario", t => t.Remetente_Id)
                .Index(t => t.Destinatario_Id)
                .Index(t => t.Remetente_Id);
            
            //CreateTable(
            //    "dbo.Usuario",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(nullable: false, maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //            Nome = c.String(nullable: false, maxLength: 200),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagem", "Remetente_Id", "dbo.Usuario");
            DropForeignKey("dbo.Mensagem", "Destinatario_Id", "dbo.Usuario");
            DropIndex("dbo.Mensagem", new[] { "Remetente_Id" });
            DropIndex("dbo.Mensagem", new[] { "Destinatario_Id" });
            //DropTable("dbo.Usuario");
            DropTable("dbo.Mensagem");
        }
    }
}
