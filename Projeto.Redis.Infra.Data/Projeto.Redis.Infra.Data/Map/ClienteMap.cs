using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Redis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Redis.Infra.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(prop => prop.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType(("varchar(200)"));
            builder.Property(x => x.Telefone2)
                .HasColumnName("Telefone2")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Rua)
                .HasColumnName("Rua")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Cep)
                .HasColumnName("Cep")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(200)");
            builder.Property(x => x.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar(200)");
        }
    }
}
