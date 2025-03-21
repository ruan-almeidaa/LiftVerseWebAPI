﻿using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.Exercicio;
using Entities.Dtos.Output.Exercicio;
using Entities.Dtos.Output.VariacaoExercicio;
using Entities.Entities;
using Shared.Paginacao;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Orquestradores
{
    public class OrquestradorExercicioVariacaoGrupo : IOrquestradorExercicioVariacaoGrupo
    {
        private readonly IMapper _mapper;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        private readonly IGrupoMuscularService _grupoMuscularService;
        public OrquestradorExercicioVariacaoGrupo(IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService, IMapper mapper, IGrupoMuscularService grupoMuscularService)
        {
            _exercicioService = exercicioService;
            _variacaoExercicioService = variacaoExercicioService;
            _mapper = mapper;
            _grupoMuscularService = grupoMuscularService;
        }

        public async Task<ResponseModel<PaginacaoModel<ExercicioDetalhadoDto>>> BuscarExercicios(int numeroPagina, int qtdRegistrosPorPagina)
        {
            PaginacaoModel<ExercicioDetalhadoDto> paginacaoExercicios = await _exercicioService.BuscarExercicios(numeroPagina, qtdRegistrosPorPagina);

            return ResponseService.CriarResponse(paginacaoExercicios, "Ok", System.Net.HttpStatusCode.OK);
        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id)
        {
            Exercicio exercicio = await _exercicioService.BuscarPorid(id);
            ExercicioDetalhadoDto exercicioDetalhadoDto = _exercicioService.ConverteEmDetalhado(exercicio);

            return ResponseService.CriarResponse(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);
        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> CriarExercicio(ExercicioCriarDto exercicioCriarDto)
        {
            Exercicio exercicioCriado = await _exercicioService.CriarExercicio(_mapper.Map<Exercicio>(exercicioCriarDto));

            ExercicioDetalhadoDto exercicioDetalhadoDto = _mapper.Map<ExercicioDetalhadoDto>(exercicioCriado);
            exercicioDetalhadoDto.GrupoMuscular = await _grupoMuscularService.BuscarPorId(exercicioCriado.GrupoMuscularId);
            return ResponseService.CriarResponse(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);

        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> EditarExercicio(ExercicioEditarDto exercicioEditarDto)
        {
            Exercicio exercicioEditado = await _exercicioService.EditarExercicio(_mapper.Map<Exercicio>(exercicioEditarDto));

            ExercicioDetalhadoDto exercicioDetalhadoDto = _mapper.Map<ExercicioDetalhadoDto>(exercicioEditado);
            exercicioDetalhadoDto.GrupoMuscular = await _grupoMuscularService.BuscarPorId(exercicioEditado.GrupoMuscularId);
            return ResponseService.CriarResponse(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);

        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> ExcluirExercicio(int id)
        {
            Exercicio exercicioParaExcluir = await _exercicioService.BuscarPorid(id);
            if (exercicioParaExcluir == null) return ResponseService.CriarResponse<ExercicioDetalhadoDto>(null, "O exercício não foi encontrado!", System.Net.HttpStatusCode.NotFound);
            bool exercicioFoiExcluido = await _exercicioService.ExcluirExercicio(exercicioParaExcluir);

            return exercicioFoiExcluido
                ? ResponseService.CriarResponse(_mapper.Map<ExercicioDetalhadoDto>(exercicioParaExcluir), "Exercício excluido com sucesso!", System.Net.HttpStatusCode.OK)
                : ResponseService.CriarResponse(_mapper.Map<ExercicioDetalhadoDto>(exercicioParaExcluir), "Houve um erro ao excluir o exercício!", System.Net.HttpStatusCode.BadRequest);

        }
    }
}
