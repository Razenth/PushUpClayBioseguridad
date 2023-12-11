using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class DepartamentoDto
{
    public int Id { get; set; }

    public string NombreDepar { get; set; }

    public int IdPaisFk { get; set; }

    public virtual Pais IdPaisFkNavigation { get; set; }
}