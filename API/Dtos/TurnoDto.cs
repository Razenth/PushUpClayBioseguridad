using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dtos;
public class TurnoDto
{
    public int Id { get; set; }
    public string NombreTurno { get; set; }

    public TimeOnly HoraTurNot { get; set; }

    public TimeOnly HoraTurnoF { get; set; }
}