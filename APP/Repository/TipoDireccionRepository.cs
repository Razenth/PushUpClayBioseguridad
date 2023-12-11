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

public class TipoDireccionRepository : GenericRepository<TipoDireccion>, ITipoDireccion
{
     private readonly BioContext _context;
     public TipoDireccionRepository(BioContext context) : base(context)
     {
         _context = context;
     }
}