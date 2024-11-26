using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.Treino;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _treinoRepository;
        private readonly IMapper _mapper;
        public TreinoService(ITreinoRepository treinoRepository, IMapper mapper)
        { 
            _treinoRepository = treinoRepository;
            _mapper = mapper;
        }

        public async Task<Treino> CriarTreino(Treino treino)
        {
            return await _treinoRepository.CriarTreino(treino);
        }

        public async Task<ResponseModel<Treino>> EditarTreino(TreinoCriarDto treinoDto)
        {
            Treino treinoEditado = _mapper.Map<Treino>(treinoDto);
            treinoEditado = await _treinoRepository.EditarTreino(treinoEditado);
            return treinoEditado != null
                ? ResponseService.CriarResponse(treinoEditado, "treino editado com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(treinoEditado, "Houve um erro ao editar o treino!", HttpStatusCode.BadRequest);
        }
    }
}
