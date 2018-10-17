namespace Mensageiro.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarEntidadeConversa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioConversa",
                c => new
                    {
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                        Conversa_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Conversa_Id })
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Conversa", t => t.Conversa_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Conversa_Id);
            
            AddColumn("dbo.Mensagem", "Conversa_Id", c => c.Int());
            CreateIndex("dbo.Mensagem", "Conversa_Id");
            AddForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagem", "Conversa_Id", "dbo.Conversa");
            DropForeignKey("dbo.UsuarioConversa", "Conversa_Id", "dbo.Conversa");
            DropForeignKey("dbo.UsuarioConversa", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.UsuarioConversa", new[] { "Conversa_Id" });
            DropIndex("dbo.UsuarioConversa", new[] { "Usuario_Id" });
            DropIndex("dbo.Mensagem", new[] { "Conversa_Id" });
            DropColumn("dbo.Mensagem", "Conversa_Id");
            DropTable("dbo.UsuarioConversa");
            DropTable("dbo.Conversa");
        }
    }
}
