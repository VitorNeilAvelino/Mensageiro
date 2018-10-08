using Mensageiro.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Mensageiro.Repositorios.SqlServer.ModelConfiguration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.Id);

            Property(u => u.Id)
                .IsRequired()
                .HasMaxLength(128);

            Property(u => u.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);

            //HasOptional(u => u.Mensagens)
            //    .WithRequired();
        }
    }
}