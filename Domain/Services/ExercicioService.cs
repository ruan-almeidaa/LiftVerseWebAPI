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
    public class ExercicioService : IExercicioService
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioService (IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }

        public async Task<Exercicio> BuscarPorid(int idExercicio)
        {
            return await _exercicioRepository.BuscarPorid(idExercicio);
        }
    }
}
