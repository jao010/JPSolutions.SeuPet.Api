using JPSolutions.SeuPet.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPSolutions.SeuPet.Api.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasComment("Tabela com os dados básicos do usuário.");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO")
                .HasColumnType("datetime");

            builder.Property(e => e.Documento)
                .IsRequired()
                .HasColumnName("DOCUMENTO")
                .HasMaxLength(14);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasMaxLength(100);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnName("NOME")
                .HasMaxLength(50);

            builder.Property(e => e.Senha)
                .IsRequired()
                .HasColumnName("SENHA")
                .HasMaxLength(50);

            builder.Property(e => e.SenhaConfirmada)
                .IsRequired()
                .HasColumnName("SENHA_CONFIRMADA")
                .HasMaxLength(50);

            builder.Property(e => e.Sobrenome)
                .IsRequired()
                .HasColumnName("SOBRENOME")
                .HasMaxLength(50);

            builder.Property(e => e.TelefoneCelular).HasColumnName("TELEFONE_CELULAR");
        }
    }
}
