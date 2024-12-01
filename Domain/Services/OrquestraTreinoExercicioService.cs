using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Entities;
using Shared.Criptografia;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestraTreinoExercicioService : IOrquestraTreinoExercicioService
    {
        private readonly IMapper _mapper;
        private readonly ITreinoService _treinoService;
        private readonly IExercicioFeitoService _exercicioFeitoService;
        public OrquestraTreinoExercicioService(IMapper mapper, ITreinoService treinoService, IExercicioFeitoService exercicioFeitoService)
        {
            _mapper = mapper;
            _treinoService = treinoService;
            _exercicioFeitoService = exercicioFeitoService;
        }

        public async Task<ResponseModel<Treino>> CriarTreinoEhExerciciosFeitos(TreinoCriarDto treinoDto)
        {
            Treino treinoAhSerCriado = _mapper.Map<Treino>(treinoDto);
            Treino treinoCriado = await _treinoService.CriarTreino(treinoAhSerCriado);

            return ResponseService.CriarResponse(treinoCriado, "Treino criado com sucesso!", HttpStatusCode.Created);
        }
    }
}
