using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Dtos.Output.Treino;
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
        Task<ResponseModel<TreinoDetalhadoDto>> CriarTreinoEhExerciciosFeitos(TreinoCriarDto treinoDto);
        Task<ResponseModel<TreinoDetalhadoDto>> EditarTreino(TreinoEditarDto treinoEditadoDto);
        Task<ResponseModel<List<TreinoDetalhadoDto>>> BuscarTreinosUsuario(int usuarioId);
        Task<ResponseModel<TreinoDetalhadoDto>> BuscarTreinoPorId(int usuarioId, int treinoId);
        Task<ResponseModel<Treino>> ExcluirTreino(int usuarioId, int treinoId);
    }
}
