using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
{
    public void Configure(EntityTypeBuilder<TipoDireccion> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipodireccion");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Descripcion).HasColumnType("text");
    }
}