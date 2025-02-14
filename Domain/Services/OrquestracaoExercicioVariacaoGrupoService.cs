using Domain.Interfaces.IServices;
using Entities.Dtos.Output.Exercicio;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestracaoExercicioVariacaoGrupoService : IOrquestracaoExercicioVariacaoGrupo
    {
        public Task<ResponseModel<ExercicioDetalhadoDto>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
