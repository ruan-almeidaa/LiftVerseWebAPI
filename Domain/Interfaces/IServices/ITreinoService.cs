﻿using Entities.Dtos.Input.Treino;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ITreinoService
    {
        Task<Treino> CriarTreino(Treino treino);
        Task<ResponseModel<Treino>> EditarTreino(TreinoCriarDto treinoDto);
    }
}
