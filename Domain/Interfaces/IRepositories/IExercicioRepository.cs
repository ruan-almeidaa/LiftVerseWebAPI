﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IExercicioRepository
    {
        Task<Exercicio> BuscarPorid(int idExercicio);
        Task<Exercicio> CriarExercicio(Exercicio exercicio);
        Task<Exercicio> EditarExercicio(Exercicio exercicio);
        Task<bool> ExcluirExercicio(Exercicio exercicio);
        Task<List<Exercicio>> BuscarExercicios(int numeroPagina, int totalItens);
        Task<int> ContarExercicios();
    }
}
