using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("tipopersona");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Descripcion).HasColumnType("text");
    }
}