using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class EnderecoUsuarioMapping : IEntityTypeConfiguration<EnderecoUsuario>
    {
        public void Configure(EntityTypeBuilder<EnderecoUsuario> builder)
        {
            builder.ToTable("ENDERECO_USUARIO");

            builder.HasIndex(e => e.UsuarioId)
                .HasName("fkIdx_25");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnName("BAIRRO")
                .HasMaxLength(100);

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnName("CIDADE")
                .HasMaxLength(100);

            builder.Property(e => e.Complemento)
                .HasColumnName("COMPLEMENTO")
                .HasMaxLength(100);

            builder.Property(e => e.Numero).HasColumnName("NUMERO");

            builder.Property(e => e.Rua)
                .IsRequired()
                .HasColumnName("RUA")
                .HasMaxLength(100);

            builder.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.EnderecoUsuario)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_25");
        }
    }
}
