using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        builder.ToTable("ContactoPersona");
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdPersonaFk, "FkPersonaC");

        builder.HasIndex(e => e.IdTpContactoFk, "FkTpContacto");

        builder.HasIndex(e => e.Descripcion, "UqCtPersona").IsUnique();

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.Descripcion).HasMaxLength(100);

        builder.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.ContactoPersonas)
            .HasForeignKey(d => d.IdPersonaFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkPersonaC");

        builder.HasOne(d => d.IdTpContactoFkNavigation).WithMany(p => p.ContactoPersonas)
            .HasForeignKey(d => d.IdTpContactoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkTpContacto");
    }
}