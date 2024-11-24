using Domain.Interfaces.IRepositories;
using Entities.Entities;
using Infra.Database;
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
        public async Task<Treino> CriarTreino(Treino treino)
        {
            await _bancoContext.Treinos.AddAsync(treino);
            await _bancoContext.SaveChangesAsync();
            return treino;
        }
    }
}
