using Domain.Dtos;
using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<Usuario>>>> BuscarTodosUsuarios()
        {
            try
            {
                ResponseModel<List<Usuario>> response = await _usuarioService.BuscarTodosUsuarios();
                return StatusCode((int)response.HttpStatusCode, response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<Usuario>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }
    }
}
