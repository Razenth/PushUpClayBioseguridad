using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona : BaseEntity
{
    public int IdPerUq { get; set; }

    public string NombrePersona { get; set; }

    public DateOnly FechaReg { get; set; }

    public int IdTpPersonaFk { get; set; }

    public int IdCategoriaP { get; set; }

    public int IdCiudadFk { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();

    public virtual ICollection<Contrato> ContratoIdClienteFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoFkNavigations { get; set; } = new List<Contrato>();
    public virtual ICollection<Programacion> Programaciones {get; set;}

    public virtual ICollection<DireccionPersona> Direccionpersonas { get; set; } = new List<DireccionPersona>();

    public virtual CategoriaPersona IdCategoriaPNavigation { get; set; }

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual TipoPersona IdTpPersonaFkNavigation { get; set; }
}
