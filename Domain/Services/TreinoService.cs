﻿using AutoMapper;
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

        public async Task<Treino> EditarTreino(TreinoEditarDto treinoDto)
        {
            return await _treinoRepository.EditarTreino(_mapper.Map<Treino>(treinoDto));
        }
    }
}
