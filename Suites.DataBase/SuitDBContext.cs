using Suites.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.DataBase
{
    public class SuitDBContext : DbContext
    {
        public SuitDBContext() : base("SuitesDBConection")
        {}
         public DbSet<Prodect> prodects { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
