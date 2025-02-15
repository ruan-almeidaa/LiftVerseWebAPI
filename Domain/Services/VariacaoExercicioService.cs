using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos.Output.VariacaoExercicio;
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
        private readonly IMapper _mapper;

        public VariacaoExercicioService (IVariacaoExercicioRepository variacaoExercicioRepository, IMapper mapper)
        {
            _variacaoExercicioRepository = variacaoExercicioRepository;
            _mapper = mapper;
        }

        public async Task<VariacaoExercicio> BuscarPorId(int idVariacao)
        {
            return await _variacaoExercicioRepository.BuscarPorId(idVariacao);
        }

        public VariacaoExercicioSimplificadoDto ConverteEmDetalhado(VariacaoExercicio variacaoExercicio)
        {
            return  _mapper.Map<VariacaoExercicioSimplificadoDto>(variacaoExercicio);

        }

        public Task<List<VariacaoExercicioSimplificadoDto>> ConverteListaEmDetalhado(List<VariacaoExercicio> variacoesExercicio)
        {
            List<VariacaoExercicioSimplificadoDto> variacoesSimplificadas = new List<VariacaoExercicioSimplificadoDto>();

            foreach(VariacaoExercicio variacaoExercicio in variacoesExercicio)
            {
                variacoesSimplificadas.Add(ConverteEmDetalhado(variacaoExercicio));
            }

            return Task.FromResult(variacoesSimplificadas);

        }
    }
}
