using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infra.Data.EntitiesConfiguration
{
    public class PokemonMasterConfiguration : IEntityTypeConfiguration<PokemonMaster>
    {
        public void Configure(EntityTypeBuilder<PokemonMaster> entity)
        {
            entity.HasKey(e => new { e.id}).HasName("PK__pokemon_master");

            entity.ToTable("pokemon_master");

            entity.Property(e => e.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.Property(e => e.name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.Property(e => e.email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");

            entity.Property(e => e.cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cpf");

            entity.Property(e => e.age)
                .HasDefaultValueSql("((0))")
                .HasColumnName("age");
        }
    }
}
