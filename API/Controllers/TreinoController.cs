﻿using Domain.Interfaces.IServices;
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
        private readonly IOrquestraTreinoExercicioService _orquestracaoService;
        private readonly ITreinoService _treinoService;
        public TreinoController(IOrquestraTreinoExercicioService orquestracaoService, ITreinoService treinoService) 
        { 
            _orquestracaoService = orquestracaoService; 
            _treinoService = treinoService;
        }
        [HttpPost]
        public async Task<ActionResult<ResponseModel<TreinoDetalhadoDto>>> CriarTreino(TreinoCriarDto treinoDto)
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

        [HttpPut]
        public async Task<ActionResult<ResponseModel<TreinoDetalhadoDto>>> EditarTreino(TreinoEditarDto treinoDto)
        {
            try
            {
                return await _orquestracaoService.EditarTreino(treinoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ResponseService.CriarResponse<TreinoDetalhadoDto>(null, $"Ocorreu um erro: {ex.Message}", System.Net.HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("BuscarTreinos")]
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
    }
}
