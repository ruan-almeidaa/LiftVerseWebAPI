﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IExercicioFeitoRepository
    {
        Task<ExercicioFeito> CriarExercicio(ExercicioFeito exercicioFeito);
        Task<List<ExercicioFeito>> BuscarExerciciosTreino(int treinoId);
        Task ExcluirExerciciosTreino(int treinoId);
    }
}
