using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;
public class PersonaDto
{
    public int Id { get; set; }

    public int IdPerUq { get; set; }

    public string NombrePersona { get; set; }

    public DateOnly FechaReg { get; set; }

    public int IdTpPersonaFk { get; set; }

    public int IdCategoriaP { get; set; }

    public int IdCiudadFk { get; set; }
}