using Mensageiro.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Mensageiro.Repositorios.SqlServer.ModelConfiguration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            Property(u => u.Nome)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}