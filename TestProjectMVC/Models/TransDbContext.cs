using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectMVC.Models
{
    public class TransDbContext:DbContext
    {
        public TransDbContext(DbContextOptions<TransDbContext> options):base(options)
        {
                
        }
        public DbSet<TransModel> Trans { get; set; }
    }
}
