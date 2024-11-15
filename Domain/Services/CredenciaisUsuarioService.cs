using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Dtos;
using Entities.Entities;
using Microsoft.IdentityModel.Tokens;
using Shared.Criptografia;
using Shared.Response;
using Shared.VariaveisAmbiente;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CredenciaisUsuarioService : ICredenciaisUsuarioService
    {
        private readonly ICredenciaisUsuarioRepository _credenciaisUsuarioRepository;
        private readonly IVariaveisService _variaveisService;
        public CredenciaisUsuarioService(ICredenciaisUsuarioRepository credenciaisUsuarioRepository, IVariaveisService variaveisService)
        {
            _credenciaisUsuarioRepository = credenciaisUsuarioRepository;
            _variaveisService = variaveisService;
        }

        public async Task<string> AutenticarUsuario(CredenciaisUsuarioDto credenciaisUsuarioDto)
        {
            credenciaisUsuarioDto.Senha = Criptografia.GerarHash(credenciaisUsuarioDto.Senha);
            CredenciaisUsuario credenciaisUsuarioParaAutenticar = await _credenciaisUsuarioRepository.BuscaCredenciaisPorEmailSenha(credenciaisUsuarioDto.Email, credenciaisUsuarioDto.Senha);

            if (credenciaisUsuarioParaAutenticar == null) throw new InvalidOperationException("Email ou senha enválidos!");

            return await GerarToken(credenciaisUsuarioParaAutenticar);

        }

        public async Task<CredenciaisUsuario> CriarCredenciaisUsuario(CredenciaisUsuario credenciaisUsuario)
        {
            return await _credenciaisUsuarioRepository.CriarCredenciais(credenciaisUsuario);    
        }

        public async Task<bool> VerificaSeExisteEmail(string email)
        {
            return await _credenciaisUsuarioRepository.VerificaSeExisteEmail(email);
        }

        private async Task<string> GerarToken(CredenciaisUsuario credenciaisUsuario)
        {
            Variaveis variaveis = await _variaveisService.BuscarVariaveisAmbiente();

            if (variaveis == null) throw new InvalidOperationException("Variáveis de ambiente não foram encontradas.");

            string chaveToken = variaveis.ChaveToken ?? throw new ArgumentNullException(nameof(variaveis.ChaveToken), "ChaveToken não pode ser nula.");
            string issuerToken = variaveis.IssuerToken ?? throw new ArgumentNullException(nameof(variaveis.IssuerToken), "IssuerToken não pode ser nula.");
            string audienceToken = variaveis.AudienceToken ?? throw new ArgumentNullException(nameof(variaveis.AudienceToken), "AudienceToken não pode ser nula.");

            var claims = new[]
            {
                new Claim("id",   credenciaisUsuario.UsuarioId.ToString()),
                new Claim("Nome", credenciaisUsuario.Email),
                new Claim("Sobrenome", credenciaisUsuario.Usuario.Sobrenome),
                new Claim("Foto", credenciaisUsuario.Usuario.Foto),
                new Claim("Email", credenciaisUsuario.Email),
                new Claim(ClaimTypes.Role, credenciaisUsuario.Usuario.Administrador ? "Admin" : "User")
            };


            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveToken));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuerToken,
                audience: audienceToken,
                claims: claims,
                expires: DateTime.Now.AddHours(100),
                signingCredentials: credencial
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
