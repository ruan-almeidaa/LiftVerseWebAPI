using Domain.Interfaces.IServices;
using Entities.Dtos.Output.Exercicio;
using Entities.Dtos.Output.VariacaoExercicio;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestracaoExercicioVariacaoGrupoService : IOrquestracaoExercicioVariacaoGrupo
    {
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        public OrquestracaoExercicioVariacaoGrupoService(IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService)
        {
            _exercicioService = exercicioService;
            _variacaoExercicioService= variacaoExercicioService;
        }
        public async Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id)
        {
            Exercicio exercicio = await _exercicioService.BuscarPorid(id);
            ExercicioDetalhadoDto exercicioDetalhadoDto = _exercicioService.ConverteEmDetalhado(exercicio);
            //VariacaoExercicioSimplificadoDto variacoesSimplificadas = await _variacaoExercicioService.ConverteListaEmDetalhado(exercicio.Variacoes);



            return ResponseService.CriarResponse<ExercicioDetalhadoDto>(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);
        }
    }
}
