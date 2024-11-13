﻿using AutoMapper;
using Domain.Interfaces.IServices;
using Entities.Dtos;
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
    public class OrquestracaoService : IOrquestracaoService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private readonly ICredenciaisUsuarioService _credenciaisUsuarioService;
        public OrquestracaoService(IUsuarioService usuarioService, IMapper mapper, ICredenciaisUsuarioService credenciaisUsuarioService)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _credenciaisUsuarioService = credenciaisUsuarioService;
        }
        public async Task<ResponseModel<Usuario>> CriaUsuarioEhCredenciais(UsuarioEhCredenciais usuarioEhCredenciais)
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
                Senha = usuarioEhCredenciais.Senha,
                UsuarioId = usuarioCriado.Id,
                Usuario = usuarioCriado
            };

            await _credenciaisUsuarioService.CriarCredenciaisUsuario(credenciaisUsuario);

            return ResponseService.CriarResponse(usuarioAhSerCriado, "Usuário criado com sucesso", HttpStatusCode.Created);

        }
    }
}
