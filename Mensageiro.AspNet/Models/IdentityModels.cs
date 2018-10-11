using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Mensageiro.AspNet.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mensageiro.AspNet.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            userIdentity.AddClaim(new Claim("Nome", Nome));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("mensageiroSqlServer", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ApplicationUser>().ToTable("Usuario");
            modelBuilder.Entity<IdentityRole>().ToTable("Perfil");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuarioPerfis");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuarioLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuarioPermissoes");
        }
    }
}