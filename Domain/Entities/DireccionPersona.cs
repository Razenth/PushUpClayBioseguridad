using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DireccionPersona : BaseEntity
{
    public string Direccion { get; set; }

    public int IdTpDireccionFk { get; set; }

    public int IdPersonaFk { get; set; }

    public virtual Persona IdPersonaFkNavigation { get; set; }

    public virtual TipoDireccion IdTpDireccionFkNavigation { get; set; }
}
