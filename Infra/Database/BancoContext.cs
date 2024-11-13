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
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CredenciaisUsuario> CredenciaisUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento de 1 para 1 entre Usuario e CredenciaisUsuario
            modelBuilder.Entity<CredenciaisUsuario>()
                .HasOne(c => c.Usuario) // CredenciaisUsuario tem um Usuario
                .WithOne() // Usuario tem um CredenciaisUsuario (sem a propriedade de navegação)
                .HasForeignKey<CredenciaisUsuario>(c => c.UsuarioId) // Chave estrangeira em CredenciaisUsuario
                .OnDelete(DeleteBehavior.Cascade);  // Exclusão em cascata configurada
        }
    }
}
