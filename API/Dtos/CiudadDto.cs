using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;
public class CiudadDto
{
    public int Id { get; set; }
    public string NombreCiudad { get; set; }
    public int IdDeparFk { get; set; }
}