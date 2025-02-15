using Entities.Dtos.Input.Exercicio;
using Entities.Dtos.Output.Exercicio;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestracaoExercicioVariacaoGrupo
    {
        Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id);
        Task<ResponseModel<ExercicioDetalhadoDto>> CriarExercicio(ExercicioCriarDto exercicioCriarDto);
    }
}
