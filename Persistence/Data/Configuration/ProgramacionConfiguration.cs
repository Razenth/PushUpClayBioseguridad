using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("programacion");

        builder.HasIndex(e => e.IdContratoFk, "FkContrato");

        builder.HasIndex(e => e.IdEmpleadoFk, "FkEmpleadouO");

        builder.HasIndex(e => e.IdTurnoFk, "FkTurno");

        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasOne(d => d.IdContratoFkNavigation).WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdContratoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkContrato");

        builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkEmpleadouO");

        builder.HasOne(d => d.IdTurnoFkNavigation).WithMany(p => p.Programaciones)
            .HasForeignKey(d => d.IdTurnoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkTurno");
    }
}