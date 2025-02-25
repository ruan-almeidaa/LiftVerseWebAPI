using Entities.Dtos.Input.Exercicio;
using Entities.Dtos.Output.Exercicio;
using Shared.Paginacao;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestradorExercicioVariacaoGrupo
    {
        Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id);
        Task<ResponseModel<ExercicioDetalhadoDto>> CriarExercicio(ExercicioCriarDto exercicioCriarDto);
        Task<ResponseModel<ExercicioDetalhadoDto>> EditarExercicio(ExercicioEditarDto exercicioEditarDto);
        Task<ResponseModel<ExercicioDetalhadoDto>> ExcluirExercicio(int id);
        Task<ResponseModel<PaginacaoModel<ExercicioDetalhadoDto>>> BuscarExercicios(int numeroPagina, int qtdRegistrosPorPagina);
    }
}
