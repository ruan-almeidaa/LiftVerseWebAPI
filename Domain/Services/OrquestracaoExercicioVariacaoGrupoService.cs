using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.Exercicio;
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
        private readonly IMapper _mapper;
        private readonly IExercicioService _exercicioService;
        private readonly IVariacaoExercicioService _variacaoExercicioService;
        private readonly IGrupoMuscularService _grupoMuscularService;
        public OrquestracaoExercicioVariacaoGrupoService(IExercicioService exercicioService, IVariacaoExercicioService variacaoExercicioService, IMapper mapper, IGrupoMuscularService grupoMuscularService)
        {
            _exercicioService = exercicioService;
            _variacaoExercicioService = variacaoExercicioService;
            _mapper = mapper;
            _grupoMuscularService = grupoMuscularService;
        }
        public async Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id)
        {
            Exercicio exercicio = await _exercicioService.BuscarPorid(id);
            ExercicioDetalhadoDto exercicioDetalhadoDto = _exercicioService.ConverteEmDetalhado(exercicio);

            return ResponseService.CriarResponse<ExercicioDetalhadoDto>(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);
        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> CriarExercicio(ExercicioCriarDto exercicioCriarDto)
        {
            Exercicio exercicioCriado = await _exercicioService.CriarExercicio(_mapper.Map<Exercicio>(exercicioCriarDto));

            ExercicioDetalhadoDto exercicioDetalhadoDto = _mapper.Map<ExercicioDetalhadoDto>(exercicioCriado);
            exercicioDetalhadoDto.GrupoMuscular = await _grupoMuscularService.BuscarPorId(exercicioCriado.GrupoMuscularId);
            return ResponseService.CriarResponse<ExercicioDetalhadoDto>(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);

        }

        public async Task<ResponseModel<ExercicioDetalhadoDto>> EditarExercicio(ExercicioEditarDto exercicioEditarDto)
        {
            Exercicio exercicioEditado = await _exercicioService.EditarExercicio(_mapper.Map<Exercicio>(exercicioEditarDto));

            ExercicioDetalhadoDto exercicioDetalhadoDto = _mapper.Map<ExercicioDetalhadoDto>(exercicioEditado);
            exercicioDetalhadoDto.GrupoMuscular = await _grupoMuscularService.BuscarPorId(exercicioEditado.GrupoMuscularId);
            return ResponseService.CriarResponse<ExercicioDetalhadoDto>(exercicioDetalhadoDto, "Ok", System.Net.HttpStatusCode.OK);

        }
    }
}
