using Mensageiro.Dominio.Entidades;
using Mensageiro.Repositorios.SqlServer.ModelConfiguration;
using System.Data.Entity;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensageiroDbContext : DbContext
    {
        public MensageiroDbContext() : base("mensageiroSqlServer")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MensageiroDbContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new MensagemConfiguration());
        }
    }
}