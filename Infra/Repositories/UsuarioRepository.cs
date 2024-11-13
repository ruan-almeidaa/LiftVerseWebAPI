using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
using Microsoft.EntityFrameworkCore;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
		private readonly BancoContext _bancoContext;
		public UsuarioRepository(BancoContext bancoContext)
		{ 
			_bancoContext = bancoContext;
		}
        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _bancoContext.Usuarios
                .AsNoTracking()
                .ToListAsync();

        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            await _bancoContext.Usuarios.AddAsync(usuario);
            await _bancoContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> EditarUsuario(Usuario usuario)
        {
            _bancoContext.ChangeTracker.Clear();
            _bancoContext.Usuarios.Update(usuario);
            await _bancoContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ExcluirUsuario(Usuario usuario)
        {
            _bancoContext.Usuarios.Remove(usuario);
            int qtdRegistrosExcluidos = await _bancoContext.SaveChangesAsync();
            return qtdRegistrosExcluidos > 0;

        }

        public async Task<bool> VerificaSeExisteNick(string nickname)
        {
            return await _bancoContext.Usuarios
                .AsNoTracking()
                .AnyAsync(u => u.Nickname == nickname);
        }
    }
}
