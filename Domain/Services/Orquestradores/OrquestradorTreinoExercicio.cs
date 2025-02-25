using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Serie;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Dtos.Output.Serie;
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

namespace Domain.Services.Orquestradores
{
    public class OrquestradorTreinoExercicio : IOrquestradorTreinoExercicio
    {
        private readonly IMapper _mapper;
        private readonly ITreinoService _treinoService;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        private readonly ISerieService _serieService;
        public OrquestradorTreinoExercicio(IMapper mapper, ITreinoService treinoService, IVariacaoExercicioService variacaoExercicioService, ISerieService serieService)
        {
            _mapper = mapper;
            _treinoService = treinoService;
            _variacaoExercicioService = variacaoExercicioService;
            _serieService = serieService;
        }

        public async Task<ResponseModel<TreinoDetalhadoDto>> BuscarTreinoPorId(int usuarioId, int treinoId)
        {
            Treino treinoBuscado = await _treinoService.BuscarTreinoPorId(treinoId);
            if (treinoBuscado == null) return ResponseService.CriarResponse<TreinoDetalhadoDto>(null, "O treino não foi encontrado!", HttpStatusCode.NotFound);
            if (treinoBuscado.UsuarioId != usuarioId) return ResponseService.CriarResponse<TreinoDetalhadoDto>(null, "O usuário não pode acessar esse treino!", HttpStatusCode.Unauthorized);


            TreinoDetalhadoDto treinoDetalhadoDto = await ConverteTreinoParaTreinoDetalhado(treinoBuscado);
            return ResponseService.CriarResponse(treinoDetalhadoDto, "Treino encontrado com sucesso!", HttpStatusCode.OK);
        }

        public async Task<ResponseModel<List<TreinoDetalhadoDto>>> BuscarTreinosUsuario(int usuarioId)
        {
            List<Treino> treinos = await _treinoService.BuscarTreinosUsuario(usuarioId);

            List<TreinoDetalhadoDto> treinosDetalhados = new List<TreinoDetalhadoDto>();
            foreach (Treino treino in treinos)
            {
                treinosDetalhados.Add(await ConverteTreinoParaTreinoDetalhado(treino));
            }

            return treinosDetalhados.Any()
                ? ResponseService.CriarResponse(treinosDetalhados, "Lista de treinos do usuário encontrada com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(treinosDetalhados, "Não foram encontrados treinos do usuário", HttpStatusCode.NotFound);
        }

        public async Task<ResponseModel<TreinoDetalhadoDto>> CriarTreino(TreinoCriarDto treinoDto)
        {
            Treino treinoCriado = await _treinoService.CriarTreino(_mapper.Map<Treino>(treinoDto));

            TreinoDetalhadoDto treinoDetalhadoDto = await ConverteTreinoParaTreinoDetalhado(treinoCriado);
            return ResponseService.CriarResponse(treinoDetalhadoDto, "Treino criado com sucesso!", HttpStatusCode.Created);
        }

        public async Task<ResponseModel<TreinoDetalhadoDto>> EditarTreino(TreinoEditarDto treinoEditadoDto)
        {

            //Cria lista com as series que serão recriadas
            List<Serie> seriesRecriadas = treinoEditadoDto.Series
                .Select(dto =>
                {
                    Serie serie = _mapper.Map<Serie>(dto);
                    serie.Id = 0;
                    return serie;
                })
                .ToList();

            //Converte o Dto de Treino, para entidade
            Treino treinoEditado = _mapper.Map<Treino>(treinoEditadoDto);

            //Ajusta as series do treino, com a nova lista
            treinoEditado.Series = seriesRecriadas;

            //Exclui do banco de dados, todas as series do treino
            await _serieService.ExcluirSeriesTreino(treinoEditadoDto.Id);

            //Edita o Treino, recriando as series
            treinoEditado = await _treinoService.EditarTreino(treinoEditado);

            TreinoDetalhadoDto treinoDetalhadoDto = await ConverteTreinoParaTreinoDetalhado(treinoEditado);
            return treinoEditado != null
                ? ResponseService.CriarResponse(treinoDetalhadoDto, "treino editado com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(treinoDetalhadoDto, "Houve um erro ao editar o treino!", HttpStatusCode.BadRequest);
        }

        public async Task<ResponseModel<Treino>> ExcluirTreino(int usuarioId, int treinoId)
        {
            Treino treinoAhSerExcluido = await _treinoService.BuscarTreinoPorId(treinoId);
            if (treinoAhSerExcluido == null) return ResponseService.CriarResponse<Treino>(null, "O treino não foi encontrado!", HttpStatusCode.NotFound);
            if (treinoAhSerExcluido.UsuarioId != usuarioId) return ResponseService.CriarResponse<Treino>(null, "O usuário não pode acessar esse treino!", HttpStatusCode.Unauthorized);

            bool treinoFoiExcluido = await _treinoService.ExcluirTreino(treinoAhSerExcluido);

            return treinoFoiExcluido
                ? ResponseService.CriarResponse(treinoAhSerExcluido, "treino excluido com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(treinoAhSerExcluido, "Houve um erro ao excluir o treino!", HttpStatusCode.BadRequest);
        }

        private async Task<TreinoDetalhadoDto> ConverteTreinoParaTreinoDetalhado(Treino treino)
        {
            TreinoDetalhadoDto treinoAhSerRetornado = _mapper.Map<TreinoDetalhadoDto>(treino);
            List<SerieDetalhadoDto> listaSeries = new List<SerieDetalhadoDto>();

            foreach (Serie serie in treino.Series)
            {
                SerieDetalhadoDto serieDetalhadoDto = await _serieService.ConverteParaSerieDetalhado(serie);
                listaSeries.Add(serieDetalhadoDto);
            }

            treinoAhSerRetornado.Series = listaSeries;

            return treinoAhSerRetornado;

        }
    }
}
