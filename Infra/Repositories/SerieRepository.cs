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
    public class SerieRepository : ISerieRepository
    {
        private readonly BancoContext _bancoContext;
        public SerieRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Serie> CriarSerie(Serie serie)
        {
            await _bancoContext.Series.AddAsync(serie);
            await _bancoContext.SaveChangesAsync();
            return serie;
        }

        public async Task<bool> ExcluirSeriesTreino(int treinoId)
        {
            _bancoContext.Series.RemoveRange(_bancoContext.Series.Where(s => s.TreinoId == treinoId));
            return await _bancoContext.SaveChangesAsync() > 0;
        }
    }
}
