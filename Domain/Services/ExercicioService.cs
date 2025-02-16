using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos.Output.Exercicio;
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
        private readonly IMapper _mapper;

        public ExercicioService (IExercicioRepository exercicioRepository, IMapper mapper)
        {
            _exercicioRepository = exercicioRepository;
            _mapper = mapper;
        }

        public async Task<Exercicio> BuscarPorid(int idExercicio)
        {
            return await _exercicioRepository.BuscarPorid(idExercicio);
        }

        public ExercicioDetalhadoDto ConverteEmDetalhado(Exercicio exercicio)
        {
            return _mapper.Map<ExercicioDetalhadoDto>(exercicio);
        }

        public async Task<Exercicio> CriarExercicio(Exercicio exercicio)
        {
            return await _exercicioRepository.CriarExercicio(exercicio);
        }

        public async Task<Exercicio> EditarExercicio(Exercicio exercicio)
        {
            return await _exercicioRepository.EditarExercicio(exercicio);
        }

        public async Task<bool> ExcluirExercicio(Exercicio exercicio)
        {
            return await _exercicioRepository.ExcluirExercicio(exercicio);
        }
    }
}
