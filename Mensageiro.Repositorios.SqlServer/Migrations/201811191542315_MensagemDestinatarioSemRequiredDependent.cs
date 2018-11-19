namespace Mensageiro.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MensagemDestinatarioSemRequiredDependent : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Mensagem", new[] { "Destinatario_Id" });
            DropIndex("dbo.Mensagem", new[] { "Remetente_Id" });
            AlterColumn("dbo.Mensagem", "Destinatario_Id", c => c.String(maxLength: 128, nullable: false));
            AlterColumn("dbo.Mensagem", "Remetente_Id", c => c.String(maxLength: 128, nullable: false));
            CreateIndex("dbo.Mensagem", "Destinatario_Id");
            CreateIndex("dbo.Mensagem", "Remetente_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Mensagem", new[] { "Remetente_Id" });
            DropIndex("dbo.Mensagem", new[] { "Destinatario_Id" });
            AlterColumn("dbo.Mensagem", "Remetente_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Mensagem", "Destinatario_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Mensagem", "Remetente_Id");
            CreateIndex("dbo.Mensagem", "Destinatario_Id");
        }
    }
}
