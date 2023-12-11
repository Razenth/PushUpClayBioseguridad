using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }

    public int IdDeparFk { get; set; }

    public virtual Departamento IdDeparFkNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
