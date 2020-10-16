using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext():base("DefaultConnection")
        {
        }

        public DbSet<Kafedra> Kafedras { get; set; }
    }
}
