using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class FotosPetMapping : IEntityTypeConfiguration<FotosPet>
    {
        public void Configure(EntityTypeBuilder<FotosPet> builder)
        {
            builder.ToTable("FOTOS_PET");

            builder.HasIndex(e => e.PetId)
                .HasName("fkIdx_100");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100);

            builder.Property(e => e.Foto)
                .IsRequired()
                .HasColumnName("FOTO")
                .HasColumnType("image");

            builder.Property(e => e.PetId).HasColumnName("PET_ID");

            builder.HasOne(d => d.Pet)
                .WithMany(p => p.FotosPet)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_100");
        }
    }
}
