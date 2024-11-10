using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<PerfilUsuario> PerfisUsuarios { get; set; }
        public DbSet<CredenciaisUsuario> CredenciaisUsuarios { get; set; }
    }
}
