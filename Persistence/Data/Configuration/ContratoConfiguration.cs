using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contrato");

        builder.HasIndex(e => e.IdClienteFk, "FkCliente");

        builder.HasIndex(e => e.IdEmpleadoFk, "FkEmpleado");

        builder.HasIndex(e => e.IdEstadoFk, "FkEstado");

        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.ContratoIdClienteFkNavigations)
            .HasForeignKey(d => d.IdClienteFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkCliente");

        builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.ContratoIdEmpleadoFkNavigations)
            .HasForeignKey(d => d.IdEmpleadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkEmpleado");

        builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Contratos)
            .HasForeignKey(d => d.IdEstadoFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkEstado");
    }
}