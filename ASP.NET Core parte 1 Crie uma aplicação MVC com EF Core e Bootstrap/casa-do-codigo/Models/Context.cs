using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace casa_do_codigo.Models{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; private set; }
        public DbSet<Order> Orders {get; set;}

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
    }
}
