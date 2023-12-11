using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Turno : BaseEntity
{
    public string NombreTurno { get; set; }

    public TimeOnly HoraTurNot { get; set; }

    public TimeOnly HoraTurnoF { get; set; }
    public virtual ICollection<Programacion> Programaciones {get; set;}
}
