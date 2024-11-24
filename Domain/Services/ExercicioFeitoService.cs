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
    public class ExercicioFeitoService : IExercicioFeitoService
    {
        private readonly IExercicioFeitoRepository _exercicioRepository;
        public ExercicioFeitoService(IExercicioFeitoRepository exercicioFeitoRepository)
        {
            _exercicioRepository = exercicioFeitoRepository;
        }

        public async Task<ExercicioFeito> CriarExercicio(ExercicioFeito exercicioFeito)
        {
            return await _exercicioRepository.CriarExercicio(exercicioFeito);
        }
    }
}
