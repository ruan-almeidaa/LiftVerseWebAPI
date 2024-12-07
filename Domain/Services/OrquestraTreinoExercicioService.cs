using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Dtos.Output.ExercicioFeito;
using Entities.Dtos.Output.Treino;
using Entities.Entities;
using Shared.Criptografia;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestraTreinoExercicioService : IOrquestraTreinoExercicioService
    {
        private readonly IMapper _mapper;
        private readonly ITreinoService _treinoService;
        private readonly IExercicioFeitoService _exercicioFeitoService;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        public OrquestraTreinoExercicioService(IMapper mapper, ITreinoService treinoService, IExercicioFeitoService exercicioFeitoService, IVariacaoExercicioService variacaoExercicioService)
        {
            _mapper = mapper;
            _treinoService = treinoService;
            _exercicioFeitoService = exercicioFeitoService;
            _variacaoExercicioService = variacaoExercicioService;
        }

        public async Task<ResponseModel<TreinoDetalhadoDto>> CriarTreinoEhExerciciosFeitos(TreinoCriarDto treinoDto)
        {
            Treino treinoCriado = await _treinoService.CriarTreino(_mapper.Map<Treino>(treinoDto));

            TreinoDetalhadoDto treinoDetalhadoDto = await ConverteTreinoParaTreinoDetalhado(treinoCriado);
            return ResponseService.CriarResponse(treinoDetalhadoDto, "Treino criado com sucesso!", HttpStatusCode.Created);
        }

        private async Task<TreinoDetalhadoDto> ConverteTreinoParaTreinoDetalhado(Treino treino)
        {
            TreinoDetalhadoDto treinoAhSerRetornado = _mapper.Map<TreinoDetalhadoDto>(treino);
            List<ExercicioFeitoDetalhadoDto> listaExerciciosFeitos = new List<ExercicioFeitoDetalhadoDto>();

            foreach (ExercicioFeito exercicioFeito in treino.ExerciciosFeitos)
            {
                ExercicioFeitoDetalhadoDto exercicioFeitoDetalhadoDto = await _exercicioFeitoService.ConverteExercicioFeitoParaDetalhado(exercicioFeito);

                listaExerciciosFeitos.Add(exercicioFeitoDetalhadoDto);
            }

            treinoAhSerRetornado.Exercicios = listaExerciciosFeitos;

            return treinoAhSerRetornado;

        }
    }
}
