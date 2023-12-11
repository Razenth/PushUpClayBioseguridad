using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
{
    public void Configure(EntityTypeBuilder<TipoContacto> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipocontacto");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Descripcion).HasColumnType("text");
    }
}