using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD;

namespace Test.Models
{
    public class TestContext : DbContext
    {
        public TestContext (DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD.Cliente> Cliente { get; set; }
    }
}
