using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokemon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Infra.Data.EntitiesConfiguration
{
    public class PokemonCapturedConfiguration : IEntityTypeConfiguration<PokemonCaptured>
    {
        public void Configure(EntityTypeBuilder<PokemonCaptured> entity)
        {
            entity.HasKey(e => new { e.pokemon_name, e.master_name }).HasName("PK__pokemon_captured");

            entity.ToTable("pokemon_captured");

            entity.Property(e => e.master_name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("master_name");

            entity.Property(e => e.pokemon_name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pokemon_name");

            entity.Property(e => e.capture_date)
                .HasColumnType("datetime")
                .HasColumnName("capture_date");
        }
    }
}
