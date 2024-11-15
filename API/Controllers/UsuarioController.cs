﻿using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
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
        public async Task<ActionResult<ResponseModel<Usuario>>> CriarUsuario(UsuarioEhCredenciaisDto usuarioEhCredenciais)
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

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ResponseModel<Usuario>>> EditarUsuario(Usuario usuario)
        {
            try
            {
                int idUsuarioToken = int.Parse(User.FindFirst("id")?.Value);
                string direitoUsuarioToken = User.FindFirst(ClaimTypes.Role)?.Value;
                if(idUsuarioToken != usuario.Id && direitoUsuarioToken != "Admin") return StatusCode(500, ResponseService.CriarResponse<Usuario>(usuario, "Acesso negado", System.Net.HttpStatusCode.Forbidden));

                ResponseModel<Usuario> response = await _usuarioService.EditarUsuario(usuario);
                return StatusCode((int)response.HttpStatusCode, response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<Usuario>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }

        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseModel<Usuario>>> ExcluirUsuario(Usuario usuario)
        {
            try
            {
                int idUsuarioToken = int.Parse(User.FindFirst("id")?.Value);
                string direitoUsuarioToken = User.FindFirst(ClaimTypes.Role)?.Value;
                if (idUsuarioToken != usuario.Id && direitoUsuarioToken != "Admin") return StatusCode(500, ResponseService.CriarResponse<Usuario>(usuario, "Acesso negado", System.Net.HttpStatusCode.Forbidden));

                ResponseModel<Usuario> response = await _usuarioService.ExcluirUsuario(usuario);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<Usuario>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }

        }

        [HttpPost("Autenticar")]
        public async Task<ActionResult<ResponseModel<string>>> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto)
        {
            try
            {
                ResponseModel<string> response = await _orquestracaoService.AutenticarUsuario(credenciaisUsuarioDto);
                return StatusCode((int)response.HttpStatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<List<Usuario>>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

    }
}
