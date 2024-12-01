﻿using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestraTreinoExercicioService
    {
        Task<ResponseModel<Treino>> CriarTreinoEhExerciciosFeitos(TreinoCriarDto treinoDto);
    }
}
