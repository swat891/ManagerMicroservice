using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagerMicroservice.Model
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }
        public DbSet<Executive> Executives { get; set; }

        public DbSet<CustomerExecutive> AssignExecutives { get; set; }

    }
}