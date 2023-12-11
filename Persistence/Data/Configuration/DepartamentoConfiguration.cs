using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuracion;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("departamento");

        builder.HasIndex(e => e.IdPaisFk, "FkPais");

        builder.Property(e => e.Id).ValueGeneratedNever();
        builder.Property(e => e.NombreDepar)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Departamentos)
            .HasForeignKey(d => d.IdPaisFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FkPais");

    }
}