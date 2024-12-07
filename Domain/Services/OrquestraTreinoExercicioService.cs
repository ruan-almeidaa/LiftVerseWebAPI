using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.ExercicioFeito;
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

        public async Task<ResponseModel<TreinoDetalhadoDto>> EditarTreino(TreinoEditarDto treinoEditadoDto)
        {
            //Primeiro exclui todos os exercicios do treino que está sendo editado
            await _exercicioFeitoService.ExcluirExerciciosTreino(treinoEditadoDto.Id);

            //Recria os exercícios que foram editados
            List<ExercicioFeito> exerciciosEditados = new List<ExercicioFeito>();
            foreach(ExercicioFeitoEditarDto exercicioEditado in treinoEditadoDto.ExerciciosFeitos)
            {
                ExercicioFeito exercicioAhCriar = _mapper.Map<ExercicioFeito>(exercicioEditado);
                exercicioAhCriar.Id = 0;
                exerciciosEditados.Add(exercicioAhCriar);
            }
            exerciciosEditados = await _exercicioFeitoService.CriarListaExerciciosFeitos(exerciciosEditados);

            treinoEditadoDto.ExerciciosFeitos = null;//Limpa os exercícios para que não precise editar
            Treino treinoEditado = await _treinoService.EditarTreino(treinoEditadoDto);
            treinoEditado.ExerciciosFeitos = exerciciosEditados; //Atualiza o treino com os exercícios que foram recriados
            
            TreinoDetalhadoDto treinoDetalhadoDto = await ConverteTreinoParaTreinoDetalhado(treinoEditado);
            return treinoEditado != null
                ? ResponseService.CriarResponse(treinoDetalhadoDto, "treino editado com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(treinoDetalhadoDto, "Houve um erro ao editar o treino!", HttpStatusCode.BadRequest);
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
