using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetSwaggerVictorLimao.Models;

namespace DotNetSwaggerVictorLimao.Data
{
    public class DotNetSwaggerVictorLimaoContext : DbContext
    {
        public DotNetSwaggerVictorLimaoContext (DbContextOptions<DotNetSwaggerVictorLimaoContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetSwaggerVictorLimao.Models.User> User { get; set; }
    }
}
