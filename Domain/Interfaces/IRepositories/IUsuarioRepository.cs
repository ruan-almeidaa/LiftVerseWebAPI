using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<bool> VerificaSeExisteNick(string nickname);
    }
}
