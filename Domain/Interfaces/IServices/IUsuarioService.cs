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
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarUsuario(int idUsuario);
        Task<Usuario> EditarUsuario(Usuario perfilUsuario);
        Task<Usuario> ExcluirUsuario(Usuario perfilUsuario);
        Task<Usuario> CriarUsuario(Usuario perfilUsuario);
    }
}
