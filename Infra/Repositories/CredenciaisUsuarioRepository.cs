using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CredenciaisUsuarioRepository : ICredenciaisUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public CredenciaisUsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<CredenciaisUsuario> CriarCredenciais(CredenciaisUsuario credenciaisUsuario)
        {
            await _bancoContext.CredenciaisUsuarios.AddAsync(credenciaisUsuario);
            await _bancoContext.SaveChangesAsync();
            return credenciaisUsuario;
        }

        public async Task<bool> VerificaSeExisteEmail(string email)
        {
            return await _bancoContext.CredenciaisUsuarios
                .AsNoTracking()
                .AnyAsync(c => c.Email == email);
        }
    }
}
