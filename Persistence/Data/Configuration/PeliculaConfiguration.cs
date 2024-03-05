using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
{
    public void Configure(EntityTypeBuilder<Pelicula> builder)
    {
        // utilizando el objeto 'builder'.
        builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

        builder.ToTable("pelicula");

        builder.Property(e => e.Id)
            .HasColumnType("int(11)")
            .HasColumnName("id");

        builder.Property(e => e.Anio)
            .HasColumnType("int(4)")
            .HasColumnName("anio");

        builder.Property(e => e.Director)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("director");

        builder.Property(e => e.Genero)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("genero");

        builder.Property(e => e.Titulo)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("titulo");

        builder.HasIndex(e => new { e.Id, e.Titulo }, "index_4");

        builder.HasIndex(e => e.Titulo, "titulo")
            .IsUnique();
    }
}
