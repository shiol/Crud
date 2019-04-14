using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class CRUDContext : DbContext
    {
        public CRUDContext (DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD.Models.Midia> Midia { get; set; }
    }
}
