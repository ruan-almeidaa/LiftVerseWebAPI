using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly BancoContext _bancoContext;

        public ExercicioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<List<Exercicio>> BuscarExercicios(int numeroPagina, int totalItens)
        {
            return await _bancoContext.Exercicios
                .Include(e => e.Variacoes)
                .Include(e => e.GrupoMuscular)
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .Skip((numeroPagina - 1) * totalItens) // Pula os registros das páginas anteriores
                .Take(totalItens) // Pega apenas os registros da página atual
                .ToListAsync();
        }

        public async Task<Exercicio> BuscarPorid(int idExercicio)
        {
            return await _bancoContext.Exercicios
                .Include(e => e.Variacoes)
                .Include(e => e.GrupoMuscular)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == idExercicio);
        }

        public async Task<int> ContarExercicios()
        {
            return await _bancoContext.Exercicios.CountAsync();
        }

        public async Task<Exercicio> CriarExercicio(Exercicio exercicio)
        {
            await _bancoContext.Exercicios.AddAsync(exercicio);
            await _bancoContext.SaveChangesAsync();
            return exercicio;
        }

        public async Task<Exercicio> EditarExercicio(Exercicio exercicio)
        {
            _bancoContext.ChangeTracker.Clear();
            _bancoContext.Exercicios.Update(exercicio);
            await _bancoContext.SaveChangesAsync();
            return await BuscarPorid(exercicio.Id);
        }

        public async Task<bool> ExcluirExercicio(Exercicio exercicio)
        {
            _bancoContext.Exercicios.Remove(exercicio);
            int qtdRegistrosExcluidos = await _bancoContext.SaveChangesAsync();
            return qtdRegistrosExcluidos > 0;
        }
    }
}
