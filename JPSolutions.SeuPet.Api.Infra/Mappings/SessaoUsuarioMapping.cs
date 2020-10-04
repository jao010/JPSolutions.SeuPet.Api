using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class SessaoUsuarioMapping : IEntityTypeConfiguration<SessaoUsuario>
    {
        public void Configure(EntityTypeBuilder<SessaoUsuario> builder)
        {
            builder.ToTable("SESSAO_USUARIO");

            builder.HasIndex(e => e.UsuarioId)
                .HasName("fkIdx_71");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.DataGeracao)
                .HasColumnName("DATA_GERACAO")
                .HasColumnType("datetime");

            builder.Property(e => e.DataLimite)
                .HasColumnName("DATA_LIMITE")
                .HasColumnType("datetime");

            builder.Property(e => e.LimiteExpiracaoMin).HasColumnName("LIMITE_EXPIRACAO_MIN");

            builder.Property(e => e.Token)
                .IsRequired()
                .HasColumnName("TOKEN")
                .HasMaxLength(100);

            builder.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.SessaoUsuario)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_71");
        }
    }
}
