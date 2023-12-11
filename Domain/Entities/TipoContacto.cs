using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TipoContacto : BaseEntity
{
    public string Descripcion { get; set; }

    public virtual ICollection<ContactoPersona> ContactoPersonas { get; set; } = new List<ContactoPersona>();
}
