using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ExercicioFeitoRepository : IExercicioFeitoRepository
    {
        private readonly BancoContext _bancoContext;
        public ExercicioFeitoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<ExercicioFeito> CriarExercicio(ExercicioFeito exercicioFeito)
        {
            await _bancoContext.ExerciciosFeitos.AddAsync(exercicioFeito);
            await _bancoContext.SaveChangesAsync();
            return exercicioFeito;
        }
    }
}
