using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Data
{
    public class MathGameContext : DbContext
    {
        public MathGameContext (DbContextOptions<MathGameContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
    }
}
