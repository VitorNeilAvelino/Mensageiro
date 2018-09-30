using Mensageiro.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Mensageiro.Repositorios.SqlServer.ModelConfiguration
{
    public class MensagemConfiguration : EntityTypeConfiguration<Mensagem>
    {
        public MensagemConfiguration()
        {
            Property(m => m.Conteudo)
                .HasMaxLength(65536)
                .IsRequired();

            HasRequired(m => m.Destinatario);
            HasRequired(m => m.Remetente);
        }
    }
}