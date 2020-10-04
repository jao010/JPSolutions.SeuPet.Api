using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JPSolutions.SeuPet.Api.Infra.Contexts
{
    public partial class SeuPetContext : DbContext
    {
        public SeuPetContext() { }

        public SeuPetContext(DbContextOptions<SeuPetContext> options) : base(options) { }

        public virtual DbSet<CategoriaPet> CategoriaPet { get; set; }
        public virtual DbSet<EnderecoUsuario> EnderecoUsuario { get; set; }
        public virtual DbSet<FotosPet> FotosPet { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<PetXTagPet> PetXTagPet { get; set; }
        public virtual DbSet<SessaoUsuario> SessaoUsuario { get; set; }
        public virtual DbSet<TagPet> TagPet { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeuPetContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
