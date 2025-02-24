using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos.Output.Serie;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        private readonly IMapper _mapper;
        public SerieService(ISerieRepository serieRepository, IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService, IMapper mapper)
        {
            _serieRepository = serieRepository;
            _exercicioService = exercicioService;
            _variacaoExercicioService = variacaoExercicioService;
            _mapper = mapper;
        }

        public async Task<SerieDetalhadoDto> ConverteParaSerieDetalhado(Serie serie)
        {
            SerieDetalhadoDto serieDetalhadoDto = _mapper.Map<SerieDetalhadoDto>(serie);

            Exercicio exercicio = await _exercicioService.BuscarPorid(serieDetalhadoDto.ExercicioId);
            serieDetalhadoDto.ExercicioTitulo = exercicio.Titulo;

            VariacaoExercicio variacaoExercicio = await _variacaoExercicioService.BuscarPorId(serieDetalhadoDto.VariacaoExercicioId);
            serieDetalhadoDto.VariacaoExerciciotitulo = variacaoExercicio.Titulo;
            return serieDetalhadoDto;
        }

        public Task<bool> ExcluirSeriesTreino(int treinoId)
        {
            return _serieRepository.ExcluirSeriesTreino(treinoId);
        }
    }
}
