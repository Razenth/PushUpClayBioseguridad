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
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
     private readonly BioContext _context;
     public CiudadRepository(BioContext context) : base(context)
     {
         _context = context;
     }
}