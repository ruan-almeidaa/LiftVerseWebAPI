using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos.Input.CredenciaisUsuario;
using Entities.Dtos.Input.Usuario;
using Entities.Dtos.Output.Usuario;
using Entities.Entities;
using Shared.Criptografia;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrquestraUsuarioCredenciaisService : IOrquestraUsuarioCredenciaisService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ICredenciaisUsuarioService _credenciaisUsuarioService;

        public OrquestraUsuarioCredenciaisService(IUsuarioService usuarioService, IMapper mapper, ICredenciaisUsuarioService credenciaisUsuarioService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _credenciaisUsuarioService = credenciaisUsuarioService;
        }

        public async Task<ResponseModel<UsuarioAutenticadoDto>> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto)
        {
            try
            {
                UsuarioAutenticadoDto usuarioAutenticadoDto = await _credenciaisUsuarioService.AutenticarUsuario(credenciaisUsuarioDto);
                return ResponseService.CriarResponse<UsuarioAutenticadoDto>(usuarioAutenticadoDto, "Usuário autenticado!", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ResponseService.CriarResponse<UsuarioAutenticadoDto>(null, "Usuário não autenticado!", HttpStatusCode.Unauthorized);
            }
        }

        public async Task<ResponseModel<Usuario>> CriaUsuarioEhCredenciais(UsuarioEhCredenciaisDto usuarioEhCredenciais)
        {
            Usuario usuarioAhSerCriado = _mapper.Map<Usuario>(usuarioEhCredenciais);

            bool nicknameExiste = await _usuarioService.VerificaSeExisteNick(usuarioEhCredenciais.Nickname);
            if (nicknameExiste) return ResponseService.CriarResponse(usuarioAhSerCriado, "Nickname já utilizado!", HttpStatusCode.Conflict);

            bool emailExiste = await _credenciaisUsuarioService.VerificaSeExisteEmail(usuarioEhCredenciais.Email);
            if (emailExiste) return ResponseService.CriarResponse(usuarioAhSerCriado, "Email já utilizado!", HttpStatusCode.Conflict);

            Usuario usuarioCriado = await _usuarioService.CriarUsuario(usuarioAhSerCriado);

            CredenciaisUsuario credenciaisUsuario = new()
            {
                Email = usuarioEhCredenciais.Email,
                Senha = Criptografia.GerarHash(usuarioEhCredenciais.Senha),
                UsuarioId = usuarioCriado.Id,
                Usuario = usuarioCriado
            };

            await _credenciaisUsuarioService.CriarCredenciaisUsuario(credenciaisUsuario);

            return ResponseService.CriarResponse(usuarioAhSerCriado, "Usuário criado com sucesso", HttpStatusCode.Created);
        }
    }
}
