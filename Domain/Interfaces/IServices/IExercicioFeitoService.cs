using Entities.Dtos.Output.ExercicioFeito;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IExercicioFeitoService
    {
        Task<ExercicioFeito> CriarExercicio(ExercicioFeito exercicioFeito);
        Task<ExercicioFeitoDetalhadoDto> ConverteExercicioFeitoParaDetalhado(ExercicioFeito exercicioFeito);
        Task ExcluirExerciciosTreino(int treinoId);
        Task<List<ExercicioFeito>> CriarListaExerciciosFeitos(List<ExercicioFeito> exercicios);
    }
}
