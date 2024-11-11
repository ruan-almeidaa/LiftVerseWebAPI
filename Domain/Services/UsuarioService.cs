using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) {
            _UsuarioRepository = usuarioRepository;
        }
        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _UsuarioRepository.BuscarTodosUsuarios();

        }

        public Task<Usuario> BuscarUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> CriarUsuario(Usuario perfilUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> EditarUsuario(Usuario perfilUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ExcluirUsuario(Usuario perfilUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
