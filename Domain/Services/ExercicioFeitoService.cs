using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos.Output.ExercicioFeito;
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
        private readonly IExercicioFeitoRepository _exercicioFeitoRepository;
        private readonly IMapper _mapper;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        public ExercicioFeitoService(IExercicioFeitoRepository exercicioFeitoRepository, IMapper mapper, IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService)
        {
            _exercicioFeitoRepository = exercicioFeitoRepository;
            _mapper = mapper;
            _exercicioService = exercicioService;
            _variacaoExercicioService = variacaoExercicioService;
        }

        public async Task<ExercicioFeitoDetalhadoDto> ConverteExercicioFeitoParaDetalhado(ExercicioFeito exercicioFeito)
        {
            ExercicioFeitoDetalhadoDto exercicioFeitoDetalhadoDto = _mapper.Map<ExercicioFeitoDetalhadoDto>(exercicioFeito);

            Exercicio exercicio = await _exercicioService.BuscarPorid(exercicioFeitoDetalhadoDto.ExercicioId);
            exercicioFeitoDetalhadoDto.ExercicioTitulo = exercicio.Titulo;

            VariacaoExercicio variacaoExercicio = await _variacaoExercicioService.BuscarPorId(exercicioFeitoDetalhadoDto.VariacaoExercicioId);
            exercicioFeitoDetalhadoDto.VariacaoExerciciotitulo = variacaoExercicio.Titulo;
            return exercicioFeitoDetalhadoDto;
        }

        public async Task<ExercicioFeito> CriarExercicio(ExercicioFeito exercicioFeito)
        {
            return await _exercicioFeitoRepository.CriarExercicio(exercicioFeito);
        }

        public async Task<List<ExercicioFeito>> CriarListaExerciciosFeitos(List<ExercicioFeito> exercicios)
        {
            List<ExercicioFeito> exerciciosCriados = new List<ExercicioFeito>();
            foreach(ExercicioFeito exercicioFeito in exercicios)
            {
                exerciciosCriados.Add(await CriarExercicio(exercicioFeito));
            }

            return exerciciosCriados;
        }

        public async Task ExcluirExerciciosTreino(int treinoId)
        {
            await _exercicioFeitoRepository.ExcluirExerciciosTreino(treinoId);
        }
    }
}
