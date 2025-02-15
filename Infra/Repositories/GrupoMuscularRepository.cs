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
    public class GrupoMuscularRepository : IGrupoMuscularRepository
    {
        private readonly BancoContext _bancoContext;

        public GrupoMuscularRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public async Task<GrupoMuscular> BuscarPorId(int id)
        {
            return await _bancoContext.GruposMusculares
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
