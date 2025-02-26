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
    public class SerieRepository : ISerieRepository
    {
        private readonly BancoContext _bancoContext;
        public SerieRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public async Task<Serie> BuscarSeriePorId(int idSerie)
        {
            return await _bancoContext.Series
                .Include(s => s.Exercicio)
                .Include(s => s.VariacaoExercicio)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == idSerie);
        }

        public async Task<Serie> CriarSerie(Serie serie)
        {
            await _bancoContext.Series.AddAsync(serie);
            await _bancoContext.SaveChangesAsync();
            return serie;
        }

        public async Task<Serie> EditarSerie(Serie serie)
        {
            _bancoContext.ChangeTracker.Clear();
            _bancoContext.Series.Update(serie);
            await _bancoContext.SaveChangesAsync();
            return await BuscarSeriePorId(serie.Id);
        }

        public async Task<bool> ExcluirSerie(Serie serie)
        {
            _bancoContext.Series.Remove(serie);
            int qtdRegistrosExcluidos = await _bancoContext.SaveChangesAsync();
            return qtdRegistrosExcluidos > 0;
        }

        public async Task<bool> ExcluirSeriesTreino(int treinoId)
        {
            _bancoContext.Series.RemoveRange(_bancoContext.Series.Where(s => s.TreinoId == treinoId));
            return await _bancoContext.SaveChangesAsync() > 0;
        }
    }
}
