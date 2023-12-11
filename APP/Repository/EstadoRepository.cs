using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace APP.Repository;

public class EstadoRepository : GenericRepository<Estado>, IEstado
{
     private readonly BioContext _context;
     public EstadoRepository(BioContext context) : base(context)
     {
         _context = context;
     }
}