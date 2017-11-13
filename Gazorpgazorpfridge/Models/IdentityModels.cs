using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Gazorpgazorpfridge.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Gazorpgazorpfridge.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Display(Name = "Nombre")]
        public string name { get; set; }

        public ICollection<Refrigerador> refrigeradores { set; get; }

        public ICollection<Receta> recetas { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            modelBuilder.Entity<CanastaBasica>().ToTable("CanastasBasicas");
            modelBuilder.Entity<Modelo>().ToTable("Modelos");
            modelBuilder.Entity<Paquete>().ToTable("Paquetes");
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Receta>().ToTable("Recetas");
            modelBuilder.Entity<Refrigerador>().ToTable("Refrigeradores");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CanastaBasica> CanastasBasicas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Refrigerador> Refrigeradores{ get; set; }

        public System.Data.Entity.DbSet<Gazorpgazorpfridge.Models.ProductForReceta> ProductForRecetas { get; set; }
    }
}