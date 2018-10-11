using Mensageiro.Dominio.Entidades;
using Mensageiro.Repositorios.SqlServer.Migrations;
using Mensageiro.Repositorios.SqlServer.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Mensageiro.Repositorios.SqlServer
{
    public class MensageiroDbContext : DbContext
    {
        public MensageiroDbContext() : base("mensageiroSqlServer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MensageiroDbContext, Configuration>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new MensagemConfiguration());
        }
    }
}