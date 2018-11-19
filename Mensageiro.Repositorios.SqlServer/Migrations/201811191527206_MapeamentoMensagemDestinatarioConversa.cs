namespace Mensageiro.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapeamentoMensagemDestinatarioConversa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa");
            DropIndex("dbo.Mensagem", new[] { "Conversa_Id" });
            DropIndex("dbo.Mensagem", new[] { "Destinatario_Id" });
            DropIndex("dbo.Mensagem", new[] { "Remetente_Id" });
            AlterColumn("dbo.Mensagem", "Conversa_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Mensagem", "Destinatario_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Mensagem", "Remetente_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Mensagem", "Conversa_Id");
            CreateIndex("dbo.Mensagem", "Destinatario_Id");
            CreateIndex("dbo.Mensagem", "Remetente_Id");
            AddForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa");
            DropIndex("dbo.Mensagem", new[] { "Remetente_Id" });
            DropIndex("dbo.Mensagem", new[] { "Destinatario_Id" });
            DropIndex("dbo.Mensagem", new[] { "Conversa_Id" });
            AlterColumn("dbo.Mensagem", "Remetente_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Mensagem", "Destinatario_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Mensagem", "Conversa_Id", c => c.Int());
            CreateIndex("dbo.Mensagem", "Remetente_Id");
            CreateIndex("dbo.Mensagem", "Destinatario_Id");
            CreateIndex("dbo.Mensagem", "Conversa_Id");
            AddForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa", "Id");
        }
    }
}
