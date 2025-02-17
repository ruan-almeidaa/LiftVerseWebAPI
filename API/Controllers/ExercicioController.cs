using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Dtos.Input.Exercicio;
using Entities.Dtos.Output.Exercicio;
using Entities.Dtos.Output.Treino;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Paginacao;
using Shared.Response;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IOrquestracaoExercicioVariacaoGrupo _orquestracaoExercicioVariacaoGrupo;

        public ExercicioController(IOrquestracaoExercicioVariacaoGrupo orquestracaoExercicioVariacaoGrupo)
        {
            _orquestracaoExercicioVariacaoGrupo = orquestracaoExercicioVariacaoGrupo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<ExercicioDetalhadoDto>>> BuscarPorId([FromRoute] int id)
        {
            try
            {
                return await _orquestracaoExercicioVariacaoGrupo.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<ExercicioDetalhadoDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<ExercicioDetalhadoDto>>> CriarExercicio(ExercicioCriarDto exercicio)
        {
            try
            {
                return await _orquestracaoExercicioVariacaoGrupo.CriarExercicio(exercicio);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ResponseService.CriarResponse<ExercicioCriarDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }
        
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<ExercicioDetalhadoDto>>> EditarExercicio(ExercicioEditarDto exercicio)
        {
            try
            {
                return await _orquestracaoExercicioVariacaoGrupo.EditarExercicio(exercicio);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ResponseService.CriarResponse<ExercicioCriarDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ResponseModel<ExercicioDetalhadoDto>>> ExcluirExercicio([FromRoute] int id)
        {
            try
            {
                return await _orquestracaoExercicioVariacaoGrupo.ExcluirExercicio(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<ExercicioDetalhadoDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<PaginacaoModel<ExercicioDetalhadoDto>>>> BuscarExercicios([FromQuery] int numeroPagina = 1, [FromQuery] int qtdRegistrosPorPagina = 20)
        {
            try
            {
                return await _orquestracaoExercicioVariacaoGrupo.BuscarExercicios(numeroPagina, qtdRegistrosPorPagina);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<ExercicioDetalhadoDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }


    }
}
