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

        public async Task<Exercicio> BuscarPorid(int idExercicio)
        {
            return await _bancoContext.Exercicios
                .Include(e => e.Variacoes)
                .Include(e => e.GrupoMuscular)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == idExercicio);
        }
    }
}
