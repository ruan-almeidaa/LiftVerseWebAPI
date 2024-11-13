using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Dtos;
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
        private readonly IOrquestracaoService _orquestracaoService;
        public UsuarioController(IUsuarioService usuarioService, IOrquestracaoService orquestracaoService)
        {
            _usuarioService = usuarioService;
            _orquestracaoService = orquestracaoService;
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

        [HttpPost]
        public async Task<ActionResult<ResponseModel<Usuario>>> CriarUsuario(UsuarioEhCredenciais usuarioEhCredenciais)
        {
            try
            {
                ResponseModel<Usuario> response = await _orquestracaoService.CriaUsuarioEhCredenciais(usuarioEhCredenciais);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<Usuario>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

    }
}
