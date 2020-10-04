using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("PET");

            builder.HasIndex(e => e.CategoriaPetId)
                .HasName("fkIdx_48");

            builder.HasIndex(e => e.UsuarioId)
                .HasName("fkIdx_60");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CategoriaPetId).HasColumnName("CATEGORIA_PET_ID");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnName("DESCRICAO")
                .HasMaxLength(250);

            builder.Property(e => e.IsVenda).HasColumnName("IS_VENDA");

            builder.Property(e => e.Localizacao)
                .IsRequired()
                .HasColumnName("LOCALIZACAO")
                .HasMaxLength(100);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnName("NOME")
                .HasMaxLength(50);

            builder.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

            builder.Property(e => e.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18, 0)");

            builder.HasOne(d => d.CategoriaPet)
                .WithMany(p => p.Pet)
                .HasForeignKey(d => d.CategoriaPetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_48");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Pet)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_60");
        }
    }
}
