using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class BioContext : DbContext
{
    public BioContext(DbContextOptions<BioContext> options) : base(options)
    {
    }
    public virtual DbSet<CategoriaPersona> Categoriapersonas { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<ContactoPersona> Contactopersonas { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DireccionPersona> Direccionpersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }
    
    public virtual DbSet<Programacion> Programaciones {get; set;}

    public virtual DbSet<TipoContacto> Tipocontactos { get; set; }

    public virtual DbSet<TipoDireccion> Tipodireccions { get; set; }

    public virtual DbSet<TipoPersona> Tipopersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<UserRol> UserRols { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}