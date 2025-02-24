using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }
        public Task<bool> ExcluirSeriesTreino(int treinoId)
        {
            return _serieRepository.ExcluirSeriesTreino(treinoId);
        }
    }
}
