using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IOrquestracaoService
    {
        Task<ResponseModel<Usuario>> CriaUsuarioEhCredenciais(UsuarioEhCredenciaisDto usuarioEhCredenciais);
        Task<ResponseModel<string>> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto);
        Task<ResponseModel<Treino>> CriarTreinoEhExerciciosFeitos(TreinoCriarDto treinoDto);
    }
}
