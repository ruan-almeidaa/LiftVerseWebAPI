using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface ISerieRepository
    {
        Task<bool> ExcluirSeriesTreino(int treinoId);
        Task<Serie> CriarSerie(Serie serie);
    }
}
