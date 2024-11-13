using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResponseModel<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return usuarios.Any()
                ? ResponseService.CriarResponse(usuarios, "Lista de usuários encontrada com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(usuarios, "Não foram encontrados usuários!", HttpStatusCode.NotFound);
        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.CriarUsuario(usuario);
        }

        public async Task<bool> VerificaSeExisteNick(string nickname)
        {
            return await _usuarioRepository.VerificaSeExisteNick(nickname);
        }
    }
}
