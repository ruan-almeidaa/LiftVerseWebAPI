using Domain.Interfaces.IServices;
using Entities.Dtos.Output.Treino;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioService _exercicioService;

        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<Exercicio>>> BuscarPorId([FromRoute] int id)
        {
            try
            {
                Exercicio exercicio = await _exercicioService.BuscarPorid(id);
                return ResponseService.CriarResponse<Exercicio>(exercicio,"Ok", System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<Exercicio>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

    }
}
