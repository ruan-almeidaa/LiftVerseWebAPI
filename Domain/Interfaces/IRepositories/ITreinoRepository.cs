﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface ITreinoRepository
    {
        Task<Treino> CriarTreino(Treino treino);
        Task<Treino> EditarTreino(Treino treino);
        Task<List<Treino>> BuscarTreinosUsuario(int usuarioId);
        Task<Treino> BuscarTreinoPorId(int treinoId);
        Task<bool> ExcluirTreino(Treino treino);
    }
}
