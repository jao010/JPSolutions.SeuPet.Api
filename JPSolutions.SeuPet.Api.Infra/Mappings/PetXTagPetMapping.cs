using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class PetXTagPetMapping : IEntityTypeConfiguration<PetXTagPet>
    {
        public void Configure(EntityTypeBuilder<PetXTagPet> builder)
        {
            builder.ToTable("PET_X_TAG_PET");

            builder.HasIndex(e => e.PetId)
                .HasName("fkIdx_83");

            builder.HasIndex(e => e.TagPetId)
                .HasName("fkIdx_86");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.PetId).HasColumnName("PET_ID");

            builder.Property(e => e.TagPetId).HasColumnName("TAG_PET_ID");

            builder.HasOne(d => d.Pet)
                .WithMany(p => p.PetXTagPet)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_83");

            builder.HasOne(d => d.TagPet)
                .WithMany(p => p.PetXTagPet)
                .HasForeignKey(d => d.TagPetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_86");
        }
    }
}
