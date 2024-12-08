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
    public class TreinoRepository : ITreinoRepository
    {
        private readonly BancoContext _bancoContext;
        public TreinoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<List<Treino>> BuscarTreinosUsuario(int usuarioId)
        {
            return await _bancoContext.Treinos
                .Where(t => t.UsuarioId == usuarioId)
                .Include(t => t.ExerciciosFeitos)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Treino> CriarTreino(Treino treino)
        {
            await _bancoContext.Treinos.AddAsync(treino);
            await _bancoContext.SaveChangesAsync();
            return treino;
        }

        public async Task<Treino> EditarTreino(Treino treino)
        {
            _bancoContext.ChangeTracker.Clear();
            _bancoContext.Treinos.Update(treino);
            await _bancoContext.SaveChangesAsync();
            return treino;
        }
    }
}
