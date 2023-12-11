using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipoPersona : BaseEntity
{

    public string Descripcion { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
