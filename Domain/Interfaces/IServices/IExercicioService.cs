using Entities.Dtos.Output.Exercicio;
using Entities.Entities;
using Shared.Paginacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IExercicioService
    {
        Task<Exercicio> BuscarPorid(int idExercicio);
        Task<Exercicio> CriarExercicio(Exercicio exercicio);
        ExercicioDetalhadoDto ConverteEmDetalhado(Exercicio exercicio);
        Task<Exercicio> EditarExercicio(Exercicio exercicio);
        Task<bool> ExcluirExercicio(Exercicio exercicio);
        Task<PaginacaoModel<ExercicioDetalhadoDto>> BuscarExercicios(int numeroPagina, int totalItens);
        Task<List<ExercicioDetalhadoDto>> ConverteListaEmDetalhado(List<Exercicio> exercicios);
    }
}
