using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IUsuarioService
    {
        Task<ResponseModel<List<Usuario>>> BuscarTodosUsuarios();
        Task<bool> VerificaSeExisteNick(string nickname);
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<ResponseModel<Usuario>> EditarUsuario(Usuario usuario);
        Task<ResponseModel<Usuario>> ExcluirUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuarioPorId(int id);
    }
}
