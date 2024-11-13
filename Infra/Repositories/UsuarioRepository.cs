﻿using Domain.Interfaces.IRepositories;
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

        public Task<Usuario> EditarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificaSeExisteNick(string nickname)
        {
            return await _bancoContext.Usuarios
                .AsNoTracking()
                .AnyAsync(u => u.Nickname == nickname);
        }
    }
}
