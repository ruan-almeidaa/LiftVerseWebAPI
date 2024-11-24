using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos;
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
    public class OrquestracaoService : IOrquestracaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ICredenciaisUsuarioService _credenciaisUsuarioService;
        private readonly ITreinoService _treinoService;
        private readonly IExercicioFeitoService _exercicioFeitoService;
        public OrquestracaoService(IUsuarioService usuarioService, IMapper mapper, ICredenciaisUsuarioService credenciaisUsuarioService, ITreinoService treinoService, IExercicioFeitoService exercicioFeitoService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _credenciaisUsuarioService = credenciaisUsuarioService;
            _treinoService = treinoService;
            _exercicioFeitoService = exercicioFeitoService;
        }

        public async Task<ResponseModel<string>> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto)
        {
            try
            {
                string token = await _credenciaisUsuarioService.AutenticarUsuario(credenciaisUsuarioDto);
                return ResponseService.CriarResponse(token, "Usuário autenticado!",HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return ResponseService.CriarResponse(ex.Message, "Usuário não autenticado!", HttpStatusCode.Unauthorized);
            }
        }

        public async Task<ResponseModel<Treino>> CriarTreinoEhExerciciosFeitos(TreinoDto treinoDto)
        {
            Treino treinoAhSerCriado = _mapper.Map<Treino>(treinoDto);
            Treino treinoCriado = await _treinoService.CriarTreino(treinoAhSerCriado);

            return ResponseService.CriarResponse(treinoCriado, "Treino criado com sucesso!", HttpStatusCode.Created);
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
