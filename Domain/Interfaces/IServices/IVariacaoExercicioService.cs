using Entities.Dtos.Output.VariacaoExercicio;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IVariacaoExercicioService
    {
        Task<VariacaoExercicio> BuscarPorId(int idVariacao);
        VariacaoExercicioSimplificadoDto ConverteEmDetalhado(VariacaoExercicio variacaoExercicio);
        Task<List<VariacaoExercicioSimplificadoDto>> ConverteListaEmDetalhado(List<VariacaoExercicio> variacoesExercicio);
    }
}
