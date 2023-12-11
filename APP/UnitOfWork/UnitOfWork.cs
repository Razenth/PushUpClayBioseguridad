using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using APP.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace APP.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BioContext _context;

    public UnitOfWork(BioContext context)
    {
        _context = context;
    }

    private CategoriaPersonaRepository _categoriaPersona;
    public ICategoriaPersona CategoriaPersonas
    {
        get
        {
            if (_categoriaPersona == null)
            {
                _categoriaPersona = new CategoriaPersonaRepository(_context);
            }
            return _categoriaPersona;
        }
    }

    private CiudadRepository _ciudad;
    public ICiudad Ciudades
    {
        get
        {
            if (_ciudad == null)
            {
                _ciudad = new CiudadRepository(_context);
            }
            return _ciudad;
        }
    }

    private ContactoPersonaRepository _contactoPersona;
    public IContactoPersona ContactoPersonas
    {
        get
        {
            if (_contactoPersona == null)
            {
                _contactoPersona = new ContactoPersonaRepository(_context);
            }
            return _contactoPersona;
        }
    }

    private ContratoRepository _contrato;
    public IContrato Contratos
    {
        get
        {
            if (_contrato == null)
            {
                _contrato = new ContratoRepository(_context);
            }
            return _contrato;
        }
    }

    private DepartamentoRepository _departamento;
    public IDepartamento Departamentos
    {
        get
        {
            if (_departamento == null)
            {
                _departamento = new DepartamentoRepository(_context);
            }
            return _departamento;
        }
    }

    private DireccionPersonaRepository _direccionPersona;
    public IDireccionPersona DireccionPersonas
    {
        get
        {
            if (_direccionPersona == null)
            {
                _direccionPersona = new DireccionPersonaRepository(_context);
            }
            return _direccionPersona;
        }
    }

    private EstadoRepository _estado;
    public IEstado Estados
    {
        get
        {
            if (_estado == null)
            {
                _estado = new EstadoRepository(_context);
            }
            return _estado;
        }
    }

    private PaisRepository _pais;
    public IPais Paises
    {
        get
        {
            if (_pais == null)
            {
                _pais = new PaisRepository(_context);
            }
            return _pais;
        }
    }

    private PersonaRepository _persona;
    public IPersona Personas
    {
        get
        {
            if (_persona == null)
            {
                _persona = new PersonaRepository(_context);
            }
            return _persona;
        }
    }

    private ProgramacionRepository _programacion;
    public IProgramacion Programaciones
    {
        get
        {
            if (_programacion == null)
            {
                _programacion = new ProgramacionRepository(_context);
            }
            return _programacion;
        }
    }

    private TipoContactoRepository _tipoContacto;
    public ITipoContacto TipoContactos
    {
        get
        {
            if (_tipoContacto == null)
            {
                _tipoContacto = new TipoContactoRepository(_context);
            }
            return _tipoContacto;
        }
    }

    private TipoDireccionRepository _tipoDireccion;
    public ITipoDireccion TipoDirecciones
    {
        get
        {
            if (_tipoDireccion == null)
            {
                _tipoDireccion = new TipoDireccionRepository(_context);
            }
            return _tipoDireccion;
        }
    }

    private TipoPersonaRepository _tipoPersona;
    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersona == null)
            {
                _tipoPersona = new TipoPersonaRepository(_context);
            }
            return _tipoPersona;
        }
    }

    private TurnoRepository _turno;
    public ITurno Turnos
    {
        get
        {
            if (_turno == null)
            {
                _turno = new TurnoRepository(_context);
            }
            return _turno;
        }
    }

    private UserRepository _user;  //CiudadRepository _ciudad
    public IUser Users
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_context);
            }
            return _user;
        }
    }
    
    private RolRepository _rol;  //CiudadRepository _ciudad
    public IRol Rols
    {
        get
        {
            if (_rol == null)
            {
                _rol = new RolRepository(_context);
            }
            return _rol;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}