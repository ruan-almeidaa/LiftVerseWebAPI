using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CredenciaisUsuarioService : ICredenciaisUsuarioService
    {
        private readonly ICredenciaisUsuarioRepository _credenciaisUsuarioRepository;
        public CredenciaisUsuarioService(ICredenciaisUsuarioRepository credenciaisUsuarioRepository)
        {
            _credenciaisUsuarioRepository = credenciaisUsuarioRepository;
        }

        public async Task<CredenciaisUsuario> CriarCredenciaisUsuario(CredenciaisUsuario credenciaisUsuario)
        {
            return await _credenciaisUsuarioRepository.CriarCredenciais(credenciaisUsuario);    
        }

        public async Task<bool> VerificaSeExisteEmail(string email)
        {
            return await _credenciaisUsuarioRepository.VerificaSeExisteEmail(email); 
        }
    }
}
