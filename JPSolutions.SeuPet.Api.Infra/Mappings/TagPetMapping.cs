using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class TagPetMapping : IEntityTypeConfiguration<TagPet>
    {
        public void Configure(EntityTypeBuilder<TagPet> builder)
        {
            builder.ToTable("TAG_PET");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.NomeTag)
                .IsRequired()
                .HasColumnName("NOME_TAG")
                .HasMaxLength(30);
        }
    }
}
