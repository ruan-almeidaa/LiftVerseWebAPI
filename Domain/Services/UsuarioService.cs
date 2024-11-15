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

        public Task<Usuario> BuscarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.CriarUsuario(usuario);
        }

        public async Task<ResponseModel<Usuario>> EditarUsuario(Usuario usuario)
        {
            Usuario usuarioEditado = await _usuarioRepository.EditarUsuario(usuario);
            return usuarioEditado != null
                ? ResponseService.CriarResponse(usuarioEditado, "Usuário editado com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(usuarioEditado, "Houve um erro ao editar o usuário!", HttpStatusCode.BadRequest);
        }

        public async Task<ResponseModel<Usuario>> ExcluirUsuario(Usuario usuario)
        {
            bool usuarioExcluido = await _usuarioRepository.ExcluirUsuario(usuario);
            return usuarioExcluido
                ? ResponseService.CriarResponse(usuario, "Usuário excluído com sucesso!", HttpStatusCode.OK)
                : ResponseService.CriarResponse(usuario, "Houve um erro ao excluir o usuário!", HttpStatusCode.BadRequest);
        }

        public async Task<bool> VerificaSeExisteNick(string nickname)
        {
            return await _usuarioRepository.VerificaSeExisteNick(nickname);
        }
    }
}
