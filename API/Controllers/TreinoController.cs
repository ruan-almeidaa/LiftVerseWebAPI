using Domain.Interfaces.IServices;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Output.Treino;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TreinoController : ControllerBase
    {
        private readonly IOrquestradorTreinoExercicio _orquestracaoService;
        public TreinoController(IOrquestradorTreinoExercicio orquestracaoService) 
        { 
            _orquestracaoService = orquestracaoService; 
        }
        [HttpPost]
        public async Task<ActionResult<ResponseModel<TreinoDetalhadoDto>>> CriarTreino(TreinoCriarDto treinoDto)
        {
            try
            {
                if(int.Parse(User.FindFirst("id")?.Value) != treinoDto.UsuarioId) return StatusCode(500, ResponseService.CriarResponse<TreinoCriarDto>(treinoDto, "Acesso negado", System.Net.HttpStatusCode.Forbidden));
                return await _orquestracaoService.CriarTreino(treinoDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ResponseService.CriarResponse<Treino>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<TreinoDetalhadoDto>>> EditarTreino(TreinoEditarDto treinoDto)
        {
            try
            {
                if (int.Parse(User.FindFirst("id")?.Value) != treinoDto.UsuarioId) return StatusCode(500, ResponseService.CriarResponse<TreinoEditarDto>(treinoDto, "Acesso negado", System.Net.HttpStatusCode.Forbidden));
                return await _orquestracaoService.EditarTreino(treinoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<TreinoDetalhadoDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<TreinoDetalhadoDto>>>> BuscarTreinosUsuario()
        {
            try
            {
                int idUsuarioToken = int.Parse(User.FindFirst("id")?.Value);
                return await _orquestracaoService.BuscarTreinosUsuario(idUsuarioToken);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<TreinoDetalhadoDto>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<TreinoDetalhadoDto>>> BuscarTreino([FromRoute] int id)
        {
            try
            {
                int idUsuarioToken = int.Parse(User.FindFirst("id")?.Value);
                return await _orquestracaoService.BuscarTreinoPorId(idUsuarioToken, id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<TreinoDetalhadoDto>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<Treino>>> ExcluirTreino([FromRoute] int id)
        {
            try
            {
                int idUsuarioToken = int.Parse(User.FindFirst("id")?.Value);
                return await _orquestracaoService.ExcluirTreino(idUsuarioToken, id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<Treino>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }
    }
}
