using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.Domain.Models;

namespace Opea.Data.Mapa
{
	public class ClienteMapa : IEntityTypeConfiguration<Cliente>
	{
		public ClienteMapa()
		{
		}

        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Porte)
                .IsRequired();

            builder.ToTable("Cliente");
        }
    }
}

