using Domain.Interfaces.IServices;
using Entities.Dtos;
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
        private readonly IOrquestracaoService _orquestracaoService;
        public TreinoController(IOrquestracaoService orquestracaoService) 
        { 
            _orquestracaoService = orquestracaoService; 
        }
        [HttpPost]
        public async Task<ActionResult<ResponseModel<Treino>>> CriarTreino(TreinoDto treinoDto)
        {
            try
            {
                return await _orquestracaoService.CriarTreinoEhExerciciosFeitos(treinoDto);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ResponseService.CriarResponse<Treino>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }
    }
}
