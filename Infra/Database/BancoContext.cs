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
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<VariacaoExercicio> VariacoesExercicios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento de 1 para 1 entre Usuario e CredenciaisUsuario
            modelBuilder.Entity<CredenciaisUsuario>()
                .HasOne(c => c.Usuario) // CredenciaisUsuario tem um Usuario
                .WithOne() // Usuario tem um CredenciaisUsuario (sem a propriedade de navegação)
                .HasForeignKey<CredenciaisUsuario>(c => c.UsuarioId) // Chave estrangeira em CredenciaisUsuario
                .OnDelete(DeleteBehavior.Cascade);  // Exclusão em cascata configurada
                                                    // Relacionamento 1:N entre Exercicio e VariacaoExercicio
            modelBuilder.Entity<Exercicio>()
                .HasMany(e => e.Variacoes) // Exercicio tem várias VariacoesExercicios
                .WithOne() // VariacaoExercicio pertence a um Exercicio
                .HasForeignKey(v => v.ExercicioId) // Chave estrangeira em VariacaoExercicio
                .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata configurada

            // Relacionamento N:1 entre Exercicio e GrupoMuscular
            modelBuilder.Entity<Exercicio>()
                .HasOne(e => e.GrupoMuscular) // Exercicio tem um GrupoMuscular
                .WithMany() // GrupoMuscular pode ter muitos Exercicios
                .HasForeignKey(e => e.GrupoMuscularId) // Chave estrangeira em Exercicio
                .OnDelete(DeleteBehavior.Restrict); // Exclusão restrita para preservar integridade referencial


            // Relacionamento entre Treino e Serie: Um Treino pode ter várias series
            modelBuilder.Entity<Treino>()
                .HasMany(t => t.Series) // Treino tem muitas series
                .WithOne() // Cada Serie pertence a um Treino
                .HasForeignKey(s => s.TreinoId) // Defina a chave estrangeira na Serie
                .OnDelete(DeleteBehavior.Cascade); // Exclusão em cascata configurada

        }
    }
}
