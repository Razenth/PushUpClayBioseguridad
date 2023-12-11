using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("persona");

        builder.HasIndex(e => e.IdCategoriaP, "FkCatP");

        builder.HasIndex(e => e.IdCiudadFk, "FkCiudad");

        builder.HasIndex(e => e.IdTpPersonaFk, "FkTpPer");

        builder.HasIndex(e => e.IdPerUq, "UqPer").IsUnique();

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(d => d.IdCategoriaPNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCategoriaP)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkCatP");

        builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCiudadFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkCiudad");

        builder.HasOne(d => d.IdTpPersonaFkNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdTpPersonaFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkTpPer");
    }
}