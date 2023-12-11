using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IUnitOfWork
{
     ICategoriaPersona CategoriaPersonas { get;}
     ICiudad Ciudades { get;}
     IContactoPersona ContactoPersonas { get;}
     IContrato Contratos { get;}
     IDepartamento Departamentos { get;}
     IDireccionPersona DireccionPersonas { get;}
     IEstado Estados { get;}
     IPais Paises { get;}
     IPersona Personas { get;}
     IProgramacion Programaciones { get;}
     ITipoContacto TipoContactos { get;}
     ITipoDireccion TipoDirecciones { get;}
     ITipoPersona TipoPersonas { get;}
     ITurno Turnos { get;}
     IUser Users {get;}
     IRol Rols {get;}
     Task<int> SaveAsync();
}