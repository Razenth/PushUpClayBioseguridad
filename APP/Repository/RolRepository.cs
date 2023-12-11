using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly BioContext _context;

    public RolRepository(BioContext context) : base(context)
    {
        _context = context;
    }
}