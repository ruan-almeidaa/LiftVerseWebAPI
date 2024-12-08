using Entities.Dtos.Input.Treino;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface ITreinoService
    {
        Task<Treino> CriarTreino(Treino treino);
        Task<Treino> EditarTreino(TreinoEditarDto treinoDto);
        Task<List<Treino>> BuscarTreinosUsuario(int usuarioId);
        Task<Treino> BuscarTreinoPorId(int treinoId);
    }
}
