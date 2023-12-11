using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class PaisConfiguration : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("Pais");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.NombrePais)
            .IsRequired()
            .HasMaxLength(50);
    }
}