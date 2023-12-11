using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("turno");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.HoraTurNot)
            .HasColumnType("time")
            .HasColumnName("HoraTurNOT");
        builder.Property(e => e.HoraTurnoF).HasColumnType("time");
        builder.Property(e => e.NombreTurno)
            .IsRequired()
            .HasMaxLength(50);
    }
}