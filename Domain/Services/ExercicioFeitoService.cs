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
        private readonly IExercicioFeitoRepository _exercicioRepository;
        private readonly IMapper _mapper;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        public ExercicioFeitoService(IExercicioFeitoRepository exercicioFeitoRepository, IMapper mapper, IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService)
        {
            _exercicioRepository = exercicioFeitoRepository;
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
            return await _exercicioRepository.CriarExercicio(exercicioFeito);
        }
    }
}
