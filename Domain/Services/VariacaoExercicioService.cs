using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class VariacaoExercicioService : IVariacaoExercicioService
    {
        private readonly IVariacaoExercicioRepository _variacaoExercicioRepository;

        public VariacaoExercicioService (IVariacaoExercicioRepository variacaoExercicioRepository)
        {
            _variacaoExercicioRepository = variacaoExercicioRepository;
        }

        public async Task<VariacaoExercicio> BuscarPorId(int idVariacao)
        {
            return await _variacaoExercicioRepository.BuscarPorId(idVariacao);
        }
    }
}
