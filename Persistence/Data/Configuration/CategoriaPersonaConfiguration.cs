using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");
        builder.ToTable("categoriapersona");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.NombreCategoria)
            .IsRequired()
            .HasMaxLength(50);
    }
}