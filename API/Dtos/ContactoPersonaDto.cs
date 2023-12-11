using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;
public class ContactoPersonaDto
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public int IdTpContactoFk { get; set; }

    public int IdPersonaFk { get; set; }
}