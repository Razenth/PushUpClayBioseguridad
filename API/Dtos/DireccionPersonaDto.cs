using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;
public class DireccionPersonaDto
{
    public int Id { get; set; }
    
    public string Direccion { get; set; }

    public int IdTpDireccionFk { get; set; }

    public int IdPersonaFk { get; set; }
}