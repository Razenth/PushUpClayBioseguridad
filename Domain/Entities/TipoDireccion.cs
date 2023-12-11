using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipoDireccion : BaseEntity
{

    public string Descripcion { get; set; }

    public virtual ICollection<DireccionPersona> Direccionpersonas { get; set; } = new List<DireccionPersona>();
}
