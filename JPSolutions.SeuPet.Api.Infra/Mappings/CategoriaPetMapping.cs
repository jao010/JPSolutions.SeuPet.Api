using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class CategoriaPetMapping : IEntityTypeConfiguration<CategoriaPet>
    {
        public void Configure(EntityTypeBuilder<CategoriaPet> builder)
        {
            builder.ToTable("CATEGORIA_PET");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.NomeCategoria)
                .IsRequired()
                .HasColumnName("NOME_CATEGORIA")
                .HasMaxLength(80);
        }
    }
}
